using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Day1.BLL.DTObjects;
namespace Day1.BLL.Interfaces
{
    public interface IVehicleService : IService<VehicleDTO>
    {
        Task<IEnumerable<VehicleDTO>> GetVehicleDTOs(string model, string brand, string name, DateTime dateBefore, DateTime dateFrom, UserDTO user);
    }
}
