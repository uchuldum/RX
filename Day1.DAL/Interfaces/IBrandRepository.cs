using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Day1.DAL.Entities;

namespace Day1.DAL.Interfaces
{
    public interface IBrandRepository : IRepository<Brand>
    {
        Task<IEnumerable<Brand>> GetByName(string name);
        Task<IEnumerable<Brand>> GetByDateFrom(DateTime date);
        Task<IEnumerable<Brand>> GetByDateBefore(DateTime date);
    }
}
