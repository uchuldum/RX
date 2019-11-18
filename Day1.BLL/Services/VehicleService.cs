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
    public class VehicleService : IVehicleService
    {
        private readonly IUnitOfWork database;
        private readonly IMapper mapper;

        public VehicleService(IUnitOfWork database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public async Task<VehicleDTO> Get(int id, UserDTO user)
        {
            if (user.Name == null) return null;
            return mapper.Map<VehicleDTO>(database.VehicleRepository.Find(x => x.Id == id && x.Creator.UserName == user.Name));
        }

        public async Task<IEnumerable<VehicleDTO>> GetAll(UserDTO user)
        {
            if (user.Name == null) return Enumerable.Empty<VehicleDTO>();
            return mapper.Map<IEnumerable<VehicleDTO>>(database.VehicleRepository.Find(x => x.Creator.UserName == user.Name));
        }

        public Task<IEnumerable<VehicleDTO>> GetVehicleDTOs(string model, string brand, string name, DateTime dateBefore, DateTime dateFrom, UserDTO user)
        {
            if (user.Name == null) return null;
            throw new NotImplementedException();
        }

        public Task Add(VehicleDTO entity, UserDTO user)
        {
            if (user.Name == null) return null;
            entity.CreateId = database.EmployeeRepository.GetByName(user.Name);
            database.VehicleRepository.Add(mapper.Map<Vehicle>(entity));
            database.Save();
            return Task.CompletedTask;
        }

        public void Remove(VehicleDTO entity, UserDTO user)
        {
            if (user.Name == null) return;
            entity.CreateId = database.EmployeeRepository.GetByName(user.Name);
            var vehicle = mapper.Map<Vehicle>(entity);
            vehicle.State = State.Remote;
            database.VehicleRepository.Update(vehicle);
            database.Save();
        }

        public void Update(VehicleDTO entity, UserDTO user)
        {
            if (user.Name == null) return;
            database.VehicleRepository.Update(mapper.Map<Vehicle>(entity));
            database.Save();
        }
    }
}
