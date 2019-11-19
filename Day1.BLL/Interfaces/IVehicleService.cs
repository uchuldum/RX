using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Day1.BLL.DTObjects;
using Day1.BLL.SearchModels;

namespace Day1.BLL.Interfaces
{
    public interface IVehicleService : IService<VehicleDTO>
    {
        Task<IEnumerable<VehicleDTO>> GetVehicleDTOs(VehicleSearchModel vehicleSearchModel, UserDTO user);
    }
}
