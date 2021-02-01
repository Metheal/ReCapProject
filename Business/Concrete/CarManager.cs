using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public List<CarDto> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetByID(int ID)
        {
            return _carDal.GetByID(ID);
        }

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            _carDal.Add(car);

        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public void DeleteByID(int ID)
        {
            _carDal.DeleteByID(ID);
        }


        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
