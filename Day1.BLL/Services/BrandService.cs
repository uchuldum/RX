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
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork database;
        private readonly IMapper mapper;

        public BrandService(IUnitOfWork database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public Task Add(BrandDTO entity, UserDTO user)
        {
            throw new NotImplementedException();
        }

        public Task<BrandDTO> Get(int id, UserDTO user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BrandDTO>> GetAll(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BrandDTO>> GetModelDTOs(string name, DateTime dateBefore, DateTime dateFrom, UserDTO user)
        {
            throw new NotImplementedException();
        }

        public void Remove(BrandDTO entity, UserDTO user)
        {
            throw new NotImplementedException();
        }

        public void Update(BrandDTO entity, UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
