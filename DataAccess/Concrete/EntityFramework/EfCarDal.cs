﻿using Core.DataAccess.EntityFramework;
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
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join cl in context.Colors
                             on c.ColorID equals cl.ColorID
                             join b in context.Brands
                             on c.BrandID equals b.BrandID
                             join ci in context.CarImages
                             on c.CarID equals ci.CarID
                             select new CarDetailDto
                             {
                                 CarID = c.CarID,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ImagePath = ci.ImagePath,
                                 ColorName = cl.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description
                             };
                return result.ToList();
                             
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
                             select new CarDetailDto
                             {
                                 CarID = c.CarID,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description
                             };
                return result.SingleOrDefault();

            }
        }
    }
}
