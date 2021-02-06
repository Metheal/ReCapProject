using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetAllByBrandID(int id);
        List<Car> GetAllByColorID(int id);
        List<Car> GetAllDailyPrice(decimal min, decimal max);
        List<Car> GetAllByModelYear(short min, short max);
        Car Get(int id);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
