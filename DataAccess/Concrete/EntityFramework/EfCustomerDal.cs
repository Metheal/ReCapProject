using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserID equals u.ID
                             select new CustomerDetailDto
                             {
                                 ID = c.ID,
                                 UserID = u.ID,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 EMail = u.EMail,
                                 Password = u.Password,
                                 CompanyName = c.CompanyName
                             };
                return result.ToList();
            }
        }
    }
}
