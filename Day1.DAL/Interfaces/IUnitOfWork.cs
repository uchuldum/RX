using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Day1.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBrandRepository BrandRepository { get; }
        IModelRepository ModelRepository { get; }
        IVehicleRepository VehicleRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        Task Save();
    }
}
