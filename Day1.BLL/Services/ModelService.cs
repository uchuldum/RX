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
    public class ModelService : IModelService
    {
        private readonly IUnitOfWork database;
        private readonly IMapper mapper;

        public ModelService(IUnitOfWork database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public async Task<ModelDTO> Add(ModelDTO entity, UserDTO user)
        {
            if (user.Name == null) return null;
            entity.CreatorId = database.EmployeeRepository.GetByName(user.Name);
            database.ModelRepository.Add(mapper.Map<Model>(entity));
            await database.Save();
            return new ModelDTO { };
        }

        public async Task<ModelDTO> Get(int id)
        {
            return mapper.Map<ModelDTO>(database.ModelRepository.Get(id));
        }

        public async Task<IEnumerable<ModelDTO>> GetAll(UserDTO user)
        {
            if (user.Name == null) return Enumerable.Empty<ModelDTO>();
            var all = await database.ModelRepository.GetAll();
            return mapper.Map<IEnumerable<ModelDTO>>(all.Where(x => x.CreatorId == database.EmployeeRepository.GetByName(user.Name) && x.State == State.Active));
        }

        public Task<IEnumerable<ModelDTO>> GetModelDTOs(string name, DateTime dateBefore, DateTime dateFrom, UserDTO user)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(int id, UserDTO user)
        {
            if (user.Name == null) return;
            var model = await database.ModelRepository.Get(id);
            model.State = State.Remote;
            database.ModelRepository.Update(model);
            await database.Save();
        }

        public async Task Update(ModelDTO entity, UserDTO user)
        {
            if (user.Name == null) return; 
            database.ModelRepository.Update(mapper.Map<Model>(entity));
            await database.Save();
        }
    }
}
