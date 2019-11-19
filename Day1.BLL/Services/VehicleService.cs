using System;
using System.Collections.Generic;
using System.Text;
using Day1.BLL.Interfaces;
using AutoMapper;
using Day1.BLL.DTObjects;
using System.Threading.Tasks;
using Day1.DAL.Interfaces;
using Day1.DAL.Entities;
using Day1.BLL.SearchModels;
using System.Linq;

namespace Day1.BLL.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IUnitOfWork database;
        private readonly IMapper mapper;

        public VehicleService(IUnitOfWork database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public async Task<VehicleDTO> Get(int id)
        {
            return mapper.Map<VehicleDTO>(await database.VehicleRepository.Get(id));
        }

        public async Task<IEnumerable<VehicleDTO>> GetAll(UserDTO user)
        {
            if (user.Name == null) return Enumerable.Empty<VehicleDTO>();
            var all = await database.VehicleRepository.GetAllWithBrandAndModel();
            return mapper.Map<IEnumerable<VehicleDTO>>(all.Where(x => x.CreatorId == database.EmployeeRepository.GetByName(user.Name) && x.State == State.Active));
        }

        public async Task<IEnumerable<VehicleDTO>> GetVehicleDTOs(VehicleSearchModel searchModel, UserDTO user)
        {
            var result = await database.VehicleRepository.GetAllWithBrandAndModel();
            if (user.Name == null) return null;
            result = result.AsQueryable();
            result = result.Where(x => x.CreatorId == database.EmployeeRepository.GetByName(user.Name));
            if (searchModel != null)
            {
                if (!string.IsNullOrEmpty(searchModel.Name))
                {
                    //if(int.TryParse(searchModel.Name))
                    result = result.Where(x => x.Name.StartsWith(searchModel.Name));
                }
                if(searchModel.ModelId.HasValue)
                    result = result.Where(x => x.ModelId == searchModel.ModelId);
                if (searchModel.BrandId.HasValue)
                    result = result.Where(x => x.BrandId == searchModel.BrandId);
                if (searchModel.BeforeDate != null)
                    result = result.Where(x => x.CreateDate < searchModel.BeforeDate);
                if (searchModel.FromDate != null)
                    result = result.Where(x => x.CreateDate > searchModel.FromDate);
            }

            return mapper.Map<IEnumerable<VehicleDTO>>(result);
        }

        public async Task<VehicleDTO> Add(VehicleDTO entity, UserDTO user)
        {
            if (user.Name == null) return null;
            entity.CreatorId = database.EmployeeRepository.GetByName(user.Name);
            database.VehicleRepository.Add(mapper.Map<Vehicle>(entity));
            await database.Save();
            return new VehicleDTO { };
        }

        public async Task Remove(int id, UserDTO user)
        {
            if (user.Name == null) return;
            var model = await database.VehicleRepository.Get(id);
            model.State = State.Remote;
            database.VehicleRepository.Update(model);
            await database.Save();
        }

        public async Task Update(VehicleDTO entity, UserDTO user)
        {
            if (user.Name == null) return;
            entity.CreatorId = database.EmployeeRepository.GetByName(user.Name);
            database.VehicleRepository.Update(mapper.Map<Vehicle>(entity));
            await database.Save();
        }
    }
}
