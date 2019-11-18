using System;
using System.Collections.Generic;
using System.Text;
using Day1.BLL.Interfaces;
using AutoMapper;
using Day1.BLL.DTObjects;
using System.Threading.Tasks;
using Day1.DAL.Interfaces;
using Day1.DAL.Entities;


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

        public Task Add(ModelDTO entity, UserDTO user)
        {
            throw new NotImplementedException();
        }

        public Task<ModelDTO> Get(int id, UserDTO user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ModelDTO>> GetAll(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ModelDTO>> GetModelDTOs(string name, DateTime dateBefore, DateTime dateFrom, UserDTO user)
        {
            throw new NotImplementedException();
        }

        public void Remove(ModelDTO entity, UserDTO user)
        {
            throw new NotImplementedException();
        }

        public void Update(ModelDTO entity, UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
