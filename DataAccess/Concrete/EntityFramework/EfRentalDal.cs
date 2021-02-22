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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Customers
                             on r.CustomerID equals c.CustomerID
                             join ca in context.Cars
                             on r.CarID equals ca.CarID
                             join u in context.Users
                             on c.UserID equals u.UserID
                             select new RentalDetailDto
                             {
                                 RentalID = r.RentalID,
                                 CarName = ca.CarName,
                                 CustomerCompanyName = c.CompanyName,
                                 CustomerEMail = u.EMail,
                                 CustomerFirstName = u.FirstName,
                                 CustomerLastName = u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }
        public RentalDetailDto GetDtoByID(int id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             where r.RentalID == id
                             join c in context.Customers
                             on r.CustomerID equals c.CustomerID
                             join ca in context.Cars
                             on r.CarID equals ca.CarID
                             join u in context.Users
                             on c.UserID equals u.UserID
                             select new RentalDetailDto
                             {
                                 RentalID = r.RentalID,
                                 CarName = ca.CarName,
                                 CustomerCompanyName = c.CompanyName,
                                 CustomerEMail = u.EMail,
                                 CustomerFirstName = u.FirstName,
                                 CustomerLastName = u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.SingleOrDefault();
            }
        }
    }
}
