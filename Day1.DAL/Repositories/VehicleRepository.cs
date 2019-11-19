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

        public async Task<IEnumerable<Vehicle>> GetAllWithBrandAndModel()
        {
            return await context.Vehicles.Include(x => x.Brand).Include(x => x.Model).ToListAsync();
        }

        public Task<IEnumerable<Vehicle>> GetByCondition()
        {
            throw new NotImplementedException();
        }
    }
}
