using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CarDto : Car
    {
        public string BrandName { get; set; }
        public string ColorName { get; set; }

    }
}
