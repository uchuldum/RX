using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Day1.DAL.Interfaces;
using Day1.DAL.Repositories;

namespace Day1.DAL.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly Day1DbContext context;

        public IBrandRepository BrandRepository { get; private set; }

        public IModelRepository ModelRepository { get; private set; }

        public IVehicleRepository VehicleRepository { get; private set; }

        public IEmployeeRepository EmployeeRepository { get; private set; }

        public EFUnitOfWork(Day1DbContext context)
        {
            this.context = context;
            BrandRepository = new BrandRepository(this.context);
            ModelRepository = new ModelRepository(this.context);
            VehicleRepository = new VehicleRepository(this.context);
            EmployeeRepository = new EmployeeRepository(this.context);
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
