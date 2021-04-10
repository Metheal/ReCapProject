using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join cl in context.Colors
                             on c.ColorID equals cl.ColorID
                             join b in context.Brands
                             on c.BrandID equals b.BrandID
                             //let images = (from ci in context.CarImages //got a better solution for this at CarManager.cs
                             //              where ci.CarID == c.CarID
                             //              select ci.ImagePath).ToList()

                             select new CarDetailDto
                             {
                                 CarID = c.CarID,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 //ImagePaths = images,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description,
                                 FindexScore = c.FindexScore
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();


            }
        }


        public CarDetailDto GetDtoByID(int id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             where c.CarID == id
                             join cl in context.Colors
                             on c.ColorID equals cl.ColorID
                             join b in context.Brands
                             on c.BrandID equals b.BrandID
                             //let images = (from ci in context.CarImages
                             //              where ci.CarID == c.CarID
                             //              select ci.ImagePath).ToList()
                             select new CarDetailDto
                             {
                                 CarID = c.CarID,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 //ImagePaths = images,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description,
                                 FindexScore = c.FindexScore
                             };
                return result.SingleOrDefault();

            }
        }
    }
}
