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
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        private readonly Day1DbContext context;

        public BrandRepository(Day1DbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Brand>> GetByDateBefore(DateTime date)
        {
            return await context.Brands.Where(b => b.CreateDate < date).ToListAsync();
        }

        public async Task<IEnumerable<Brand>> GetByDateFrom(DateTime date)
        {
            return await context.Brands.Where(b => b.CreateDate > date).ToListAsync();
        }

        public async Task<IEnumerable<Brand>> GetByName(string name)
        {
            return await context.Brands.Where(b => b.Name == name).ToListAsync();
        }
    }
}
