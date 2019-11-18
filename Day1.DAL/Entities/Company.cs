using System;
using System.Collections.Generic;
using System.Text;

namespace Day1.DAL.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string Creator { get; set; }
    }
}
