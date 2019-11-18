using System;
using System.Collections.Generic;
using System.Text;

namespace Day1.DAL.Entities
{
    public class Vehicle : BaseEntity
    {
        public string Name { get; set; }
        public string GovernmentNumber { get; set; }
        public DateTime CreateDate { get; set; }

        public string CreatorId { get; set; }
        public Employee Creator { get; set; }

        public int ModelId{ get; set; }
        public Model Model { get; set; }

        public int  BrandId{ get; set; }
        public Brand Brand { get; set; }

        public string CarBrand { get; set; }
        public string CarModel { get; set; }
    }
}
