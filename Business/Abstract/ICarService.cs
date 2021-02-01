using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<CarDto> GetAll();
        Car GetByID(int ID);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        void DeleteByID(int ID);
    }
}
