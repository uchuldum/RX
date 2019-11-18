using System;
using System.Collections.Generic;
using System.Text;
using Day1.DAL.Interfaces;
using Day1.DAL.Entities;
using Day1.DAL.EF;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Day1.DAL.Repositories
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        private readonly Day1DbContext context;

        public VehicleRepository(Day1DbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Vehicle>> GetByBrand(string brand)
        {
            return await context.Vehicles.Where(v => v.Brand.Name == brand).ToListAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetByDateBefore(DateTime date)
        {
            return await context.Vehicles.Where(v => v.CreateDate < date).ToListAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetByDateFrom(DateTime date)
        {
            return await context.Vehicles.Where(v => v.CreateDate > date).ToListAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetByModel(string model)
        {
            return await context.Vehicles.Where(v => v.Model.Name == model).ToListAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetByName(string name)
        {
            return await context.Vehicles.Where(v => v.Name == name).ToListAsync();
        }
    }
}
