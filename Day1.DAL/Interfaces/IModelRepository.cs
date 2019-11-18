using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Day1.DAL.Entities;


namespace Day1.DAL.Interfaces
{
    public interface IModelRepository : IRepository<Model>
    {
        Task<IEnumerable<Model>> GetByName(string name);
        Task<IEnumerable<Model>> GetByDateFrom(DateTime date);
        Task<IEnumerable<Model>> GetByDateBefore(DateTime date);
    }
}
