using Business.Concrete;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            int i;
            Console.WriteLine("==========TUM RENKLER==========");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine($"{color.ColorID}: {color.ColorName}");
            }

            Console.WriteLine();
            Console.WriteLine("==========TUM MARKALAR==========");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine($"{brand.BrandID}: {brand.BrandName}");
            }

            Console.WriteLine();
            Console.WriteLine("==========TUM ARACLAR==========");
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine($"{car.ID}: " +
                    $"{car.BrandName} " +
                    $"{car.CarName} " +
                    $"{car.Description} " +
                    $"{car.ModelYear} " +
                    $"{car.ColorName}: " +
                    $"gunluk {car.DailyPrice} TL");
            }

            i = 0;
            Console.WriteLine();
            Console.WriteLine("Gunluk 100 TL ile 250 TL arasindaki araclarimiz:");
            foreach (var car in carManager.GetAllDailyPrice(100, 250))
            {
                Console.WriteLine(//$"{car.ID}: " +
                    $"{++i}: " +
                    $"{brandManager.Get(car.BrandID).BrandName} " +
                    $"{car.CarName} " +
                    $"{car.Description} " +
                    $"{car.ModelYear} " +
                    $"{colorManager.Get(car.ColorID).ColorName}: " +
                    $"gunluk {car.DailyPrice} TL");
            }

            i = 0;
            Console.WriteLine();
            Console.WriteLine("2019-2021 Model Araclarimiz:");
            foreach (var car in carManager.GetAllByModelYear(2019, 2021))
            {
                Console.WriteLine(//$"{car.ID}: " +
                    $"{++i}: " +
                    $"{brandManager.Get(car.BrandID).BrandName} " +
                    $"{car.CarName} " +
                    $"{car.Description} " +
                    $"{car.ModelYear} " +
                    $"{colorManager.Get(car.ColorID).ColorName}: " +
                    $"gunluk {car.DailyPrice} TL");
            }

            i = 0;
            Console.WriteLine();
            Console.WriteLine("Kirmizi Renkli Araclarimiz:");
            foreach (var car in carManager.GetAllByColorID(1))
            {
                Console.WriteLine(//$"{car.ID}: " +
                    $"{++i}: " +
                    $"{brandManager.Get(car.BrandID).BrandName} " +
                    $"{car.CarName} " +
                    $"{car.Description} " +
                    $"{car.ModelYear} " +
                    $"{colorManager.Get(car.ColorID).ColorName}: " +
                    $"gunluk {car.DailyPrice} TL");
            }

            i = 0;
            Console.WriteLine();
            Console.WriteLine("Renault Marka Araclarimiz:");
            foreach (var car in carManager.GetAllByBrandID(1))
            {
                Console.WriteLine(//$"{car.ID}: " +
                    $"{++i}: " +
                    $"{brandManager.Get(car.BrandID).BrandName} " +
                    $"{car.CarName} " +
                    $"{car.Description} " +
                    $"{car.ModelYear} " +
                    $"{colorManager.Get(car.ColorID).ColorName}: " +
                    $"gunluk {car.DailyPrice} TL");
            }

            //// araba ekleme
            //carManager.Add(new Car() { BrandID = 6, ColorID = 4, CarName = "Outback", DailyPrice = 400, Description = "2.0 IS", ModelYear = 2017 });
            //// araba guncelleme
            //carManager.Update(new Car() { ID = 6, BrandID = 4, ColorID = 5, CarName = "Corolla", DailyPrice = 260, Description = "1.4 D-4D", ModelYear = 2019 });
            //// araba silme
            //carManager.Delete(new Car() { ID = 3 });

        }
    }
}
