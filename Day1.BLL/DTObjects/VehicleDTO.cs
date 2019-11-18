using System;
using System.Collections.Generic;
using System.Text;

namespace Day1.BLL.DTObjects
{
    public class VehicleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GovernmentNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateId { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
    }
}
