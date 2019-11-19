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
        public string CreatorId { get; set; }
        public int ModelId  { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
    }
}
