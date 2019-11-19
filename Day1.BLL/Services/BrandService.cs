using System;
using System.Collections.Generic;
using System.Text;
using Day1.BLL.Interfaces;
using AutoMapper;
using Day1.BLL.DTObjects;
using System.Threading.Tasks;
using Day1.DAL.Interfaces;
using Day1.DAL.Entities;
using System.Linq;

namespace Day1.BLL.Services
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork database;
        private readonly IMapper mapper;

        public BrandService(IUnitOfWork database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public async Task<BrandDTO> Add(BrandDTO entity, UserDTO user)
        {
            if (user.Name == null) return null;
            entity.CreatorId = database.EmployeeRepository.GetByName(user.Name);
            database.BrandRepository.Add(mapper.Map<Brand>(entity));
            await database.Save();
            return new BrandDTO { };
        }

        public async Task<BrandDTO> Get(int id)
        {
            return mapper.Map<BrandDTO>(await database.BrandRepository.Get(id));
        }

        public async Task<IEnumerable<BrandDTO>> GetAll(UserDTO user)
        {
            if (user.Name == null) return Enumerable.Empty<BrandDTO>();
            var all = await database.BrandRepository.GetAll();
            return mapper.Map<IEnumerable<BrandDTO>>(all.Where(x => x.CreatorId == database.EmployeeRepository.GetByName(user.Name) && x.State == State.Active));
        }

        public Task<IEnumerable<BrandDTO>> GetModelDTOs(string name, DateTime dateBefore, DateTime dateFrom, UserDTO user)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(int id, UserDTO user)
        {
            if (user.Name == null) return;
            var model = await database.BrandRepository.Get(id);
            model.State = State.Remote;
            database.BrandRepository.Update(model);
            await database.Save();
        }

        public async Task Update(BrandDTO entity, UserDTO user)
        {
            if (user.Name == null) return;
            database.BrandRepository.Update(mapper.Map<Brand>(entity));
            database.Save();
        }
    }
}
