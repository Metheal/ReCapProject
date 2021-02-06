using DataAccess.Abstract;
using Entities.Concrete;
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
                new Car { ID = 1, BrandID = 1, ColorID = 6, ModelYear = 2019, DailyPrice = 150, Description = "Megane 1.5 dCi" },
                new Car { ID = 2, BrandID = 2, ColorID = 2, ModelYear = 2018, DailyPrice = 90, Description = "Egea 1.3 Multijet" },
                new Car { ID = 3, BrandID = 3, ColorID = 3, ModelYear = 2016, DailyPrice = 250, Description = "Jetta 1.4 TSI" },
                new Car { ID = 4, BrandID = 5, ColorID = 1, ModelYear = 2017, DailyPrice = 300, Description = "Focus 1.5 TDCi" },
                new Car { ID = 5, BrandID = 6, ColorID = 1, ModelYear = 2021, DailyPrice = 1200, Description = "WRX STI 2.5" }
            };
        }

        public void Add(Car car)
        {
            var carToAdd = _cars.Find(c => c.ID == car.ID);
            if (carToAdd == null)
            {
                _cars.Add(car);
                Console.WriteLine("A new car added: {0}", car.ID);
            }
            else
            {
                Console.WriteLine("Error: Car is already in the list or the ID is cannot be used: {0}", car.ID);
            }
        }

        public void Delete(Car car)
        {
            Car carToDelete;

            carToDelete = _cars.SingleOrDefault(c=>c.ID==car.ID);
            _cars.Remove(carToDelete);
        }

        public void DeleteByID(int ID)
        {
            Car carToDelete;

            carToDelete = _cars.Find(c => c.ID == ID);
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

        public List<CarDto> GetAll()
        {
            var cars = from c in _cars
                       //join b in _brands on c.BrandID equals b.BrandID
                       //join cl in _colors on c.ColorID equals cl.ColorID
                       select new CarDto
                       {
                           ID = c.ID,
                           //BrandName = b.BrandName,
                           //ColorName = cl.ColorName,
                           DailyPrice = c.DailyPrice,
                           ModelYear = c.ModelYear,
                           Description = c.Description,
                       };
            return cars.ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetByID(int ID)
        {
            return _cars.Find(c=>c.ID==ID);
        }

        public void Update(Car car)
        {
            Car carToUpdate;
            carToUpdate = _cars.SingleOrDefault(c => c.ID == car.ID);
            carToUpdate.BrandID = car.BrandID;
            carToUpdate.ColorID = car.ColorID;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
