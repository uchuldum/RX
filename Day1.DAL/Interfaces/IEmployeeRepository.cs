using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Day1.DAL.Entities;

namespace Day1.DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        string GetByName(string name);
    }
}
