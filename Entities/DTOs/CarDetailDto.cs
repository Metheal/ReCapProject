using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int CarID { get; set; }
        public string BrandName { get; set; }
        public string CarName { get; set; }
        public List<string> ImagePaths { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
        public short ModelYear { get; set; }
        public string Description { get; set; }
        public int FindexScore { get; set; }
    }
}
