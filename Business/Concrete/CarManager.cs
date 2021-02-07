using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public void Add(Car car)
        {
            if (car.DailyPrice <= 0)
            {
                Console.WriteLine("Araba eklenemedi! Arabanin gunluk fiyati 0'dan buyuk olmalidir!");
            }
            else if (car.CarName.Length < 3)
            {
                Console.WriteLine("Aracin ismi 3 karakterden kisa olamaz!");
            }
            else
            {
                _carDal.Add(car);
            }

        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }


        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public Car Get(int id)
        {
            return _carDal.Get(c => c.ID == id);
        }

        public List<Car> GetAllByBrandID(int id)
        {
            return _carDal.GetAll(c => c.BrandID == id);
        }

        public List<Car> GetAllByColorID(int id)
        {
            return _carDal.GetAll(c => c.ColorID == id);
        }

        public List<Car> GetAllDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }

        public List<Car> GetAllByModelYear(short min, short max)
        {
            return _carDal.GetAll(c => c.ModelYear >= min && c.ModelYear <= max);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
