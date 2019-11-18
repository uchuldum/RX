using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Day1.DAL.Entities;

namespace Day1.DAL.Interfaces
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        Task<IEnumerable<Vehicle>> GetByBrand(string brand);
        Task<IEnumerable<Vehicle>> GetByModel(string model);
        Task<IEnumerable<Vehicle>> GetByName(string name);
        Task<IEnumerable<Vehicle>> GetByDateFrom(DateTime date);
        Task<IEnumerable<Vehicle>> GetByDateBefore(DateTime date);
    }
}
