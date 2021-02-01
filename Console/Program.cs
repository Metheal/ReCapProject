using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());


            carManager.Add(new Car() { ID = 6, BrandID = 4, ColorID = 2, DailyPrice = 220, Description = "Corolla 1.33 LPG", ModelYear = 2018 });
            carManager.Add(new Car() { ID = 7, BrandID = 6, ColorID = 4, DailyPrice = 400, Description = "Outback 2.0 IS", ModelYear = 2017 });
            carManager.Update(new Car() { ID = 6, BrandID = 4, ColorID = 5, DailyPrice = 260, Description = "Corolla 1.4 D-4D", ModelYear = 2019 });
            carManager.DeleteByID(4);

            Console.WriteLine();
            Console.WriteLine("------- Tum araclarimiz -------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0}: {1} {2} {3} {4}: gunluk {5} TL", car.ID, car.ColorName, car.BrandName, car.Description, car.ModelYear, car.DailyPrice);
            }

            Car mostRentedCar = carManager.GetByID(3);

            Console.WriteLine("\nEn cok kiralanan aracimiz:\n{0}: {1} {2}: gunluk {3} TL", mostRentedCar.ID, mostRentedCar.Description, mostRentedCar.ModelYear, mostRentedCar.DailyPrice); 


        }
    }
}
