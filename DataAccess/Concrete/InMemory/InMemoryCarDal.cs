using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { CarID = 1, BrandID = 1, ColorID = 6, ModelYear = 2019, DailyPrice = 150, Description = "Megane 1.5 dCi" },
                new Car { CarID = 2, BrandID = 2, ColorID = 2, ModelYear = 2018, DailyPrice = 90, Description = "Egea 1.3 Multijet" },
                new Car { CarID = 3, BrandID = 3, ColorID = 3, ModelYear = 2016, DailyPrice = 250, Description = "Jetta 1.4 TSI" },
                new Car { CarID = 4, BrandID = 5, ColorID = 1, ModelYear = 2017, DailyPrice = 300, Description = "Focus 1.5 TDCi" },
                new Car { CarID = 5, BrandID = 6, ColorID = 1, ModelYear = 2021, DailyPrice = 1200, Description = "WRX STI 2.5" }
            };
        }

        public void Add(Car car)
        {
            var carToAdd = _cars.Find(c => c.CarID == car.CarID);
            if (carToAdd == null)
            {
                _cars.Add(car);
                Console.WriteLine("A new car added: {0}", car.CarID);
            }
            else
            {
                Console.WriteLine("Error: Car is already in the list or the ID is cannot be used: {0}", car.CarID);
            }
        }

        public void Delete(Car car)
        {
            Car carToDelete;

            carToDelete = _cars.SingleOrDefault(c=>c.CarID==car.CarID);
            _cars.Remove(carToDelete);
        }

        public void DeleteByID(int ID)
        {
            Car carToDelete;

            carToDelete = _cars.Find(c => c.CarID == ID);
            if (carToDelete != null)
            {
                _cars.Remove(carToDelete);
                Console.WriteLine("Car removed: {0}", ID);
            }
            else
            {
                Console.WriteLine("Car cannot be found: {0}", ID);
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetByID(int ID)
        {
            return _cars.Find(c=>c.CarID==ID);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public CarDetailDto GetDtoByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate;
            carToUpdate = _cars.SingleOrDefault(c => c.CarID == car.CarID);
            carToUpdate.BrandID = car.BrandID;
            carToUpdate.ColorID = car.ColorID;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
