using Day1.BLL.DTObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Day1.BLL.Interfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity entity, UserDTO user);
        Task Remove(int id, UserDTO user);
        Task Update(TEntity entity, UserDTO user);

        Task<IEnumerable<TEntity>> GetAll(UserDTO user);
        Task<TEntity> Get(int id);
    }
}
