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
                             on c.UserID equals u.UserID
                             select new CustomerDetailDto
                             {
                                 CustomerID = c.CustomerID,
                                 UserID = u.UserID,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 EMail = u.EMail,
                                 CompanyName = c.CompanyName
                             };
                return result.ToList();
            }
        }

        public CustomerDetailDto GetDtoByID(int id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserID equals u.UserID
                             select new CustomerDetailDto
                             {
                                 CustomerID = c.CustomerID,
                                 UserID = u.UserID,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 EMail = u.EMail,
                                 CompanyName = c.CompanyName,
                                 FindexScore = c.FindexScore
                             };
                return result.SingleOrDefault(c => c.CustomerID == id);
            }
        }
    }
}
