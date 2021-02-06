using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {

        List<Brand> _brands;
        public InMemoryBrandDal()
        {
            _brands = new List<Brand>
            {
                new Brand { BrandID = 1, BrandName = "Renault" },
                new Brand { BrandID = 2, BrandName = "Fiat" },
                new Brand { BrandID = 3, BrandName = "Volkswagen" },
                new Brand { BrandID = 4, BrandName = "Toyota" },
                new Brand { BrandID = 5, BrandName = "Ford" },
                new Brand { BrandID = 6, BrandName = "Subaru" },
            };
        }
        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }
        public void Add(Brand brand)
        {
            throw new NotImplementedException();
        }

        public void Update(Brand brand)
        {
            throw new NotImplementedException();
        }

        public void Delete(Brand brand)
        {
            throw new NotImplementedException();
        }
    }
}
