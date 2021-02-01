using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        Car GetByID(int ID);
        List<CarDto> GetAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        void DeleteByID(int ID);
    }
}
