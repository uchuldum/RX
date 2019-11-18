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
    public class ModelRepository : Repository<Model>, IModelRepository
    {
        private readonly Day1DbContext context;

        public ModelRepository(Day1DbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Model>> GetByDateBefore(DateTime date)
        {
            return await context.Models.Where(m => m.CreateDate < date).ToListAsync(); 
        }

        public async Task<IEnumerable<Model>> GetByDateFrom(DateTime date)
        {
            return await context.Models.Where(m => m.CreateDate > date).ToListAsync();
        }

        public async Task<IEnumerable<Model>> GetByName(string name)
        {
            return await context.Models.Where(m => m.Name == name).ToListAsync();
        }
    }
}
