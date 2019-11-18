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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Day1DbContext context;

        public EmployeeRepository(Day1DbContext context) 
        {
            this.context = context;
        }

        public string GetByName(string name)
        {
            return context.Employees.Where(e => e.UserName == name).Select(e => e.Id).FirstOrDefault().ToString();
        }
    }
}
