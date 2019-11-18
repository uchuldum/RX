using System;
using System.Collections.Generic;
using System.Text;

namespace Day1.DAL.Entities
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }

        public string CreatorId { get; set; }
        public Employee Creator { get; set; }
    }
}
