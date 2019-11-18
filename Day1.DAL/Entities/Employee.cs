using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
namespace Day1.DAL.Entities
{
    public class Employee : IdentityUser
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
