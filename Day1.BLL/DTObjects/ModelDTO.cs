using System;
using System.Collections.Generic;
using System.Text;

namespace Day1.BLL.DTObjects
{
    public class ModelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatorId { get; set; }
    }
}
