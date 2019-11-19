using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Day1.DAL.Entities;

namespace Day1.DAL.Interfaces
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        Task<IEnumerable<Vehicle>> GetAllWithBrandAndModel();
        Task<IEnumerable<Vehicle>> GetByCondition();
    }
}
