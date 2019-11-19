using System;
using System.Collections.Generic;
using System.Text;

namespace Day1.BLL.SearchModels
{
    public class VehicleSearchModel
    {
        public string Name { get; set; }
        public DateTime? BeforeDate { get; set; }
        public DateTime? FromDate { get; set; }
        public int? ModelId { get; set; }
        public int? BrandId { get; set; }
    }
}
