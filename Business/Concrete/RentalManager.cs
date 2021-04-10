using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarService _carService;
        ICustomerService _customerService;
        public RentalManager(IRentalDal rentalDal, ICarService carService, ICustomerService customerService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _customerService = customerService;
        }

        //[SecuredOperation("rental.add,admin")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(CheckFindexScore(rental.CustomerID, rental.CarID));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(rental);
            return new SuccessResult(rental.RentalID.ToString());
        }

        [SecuredOperation("rental.delete,admin")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        [SecuredOperation("rental.list,admin")]
        public IDataResult<Rental> GetByID(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalID == id));
        }

        [SecuredOperation("rental.list,admin")]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        [SecuredOperation("rental.list,admin")]
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        [SecuredOperation("rental.update,admin")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        [SecuredOperation("rental.list, admin")]
        public IDataResult<RentalDetailDto> GetDtoByID(int id)
        {
            return new SuccessDataResult<RentalDetailDto>(_rentalDal.GetDtoByID(id));
        }

        // this one is to be called when a user wants to rent a car
        // checks if the car is available at a given time
        // returns null if no matches
        // better method could be possible to write but it works for now
        public IDataResult<List<Rental>> GetSingleByCarID(int carID, DateTime rentDate, DateTime returnDate)
        {
            return new SuccessDataResult<List<Rental>>(
                _rentalDal.GetAll(
                r => r.CarID == carID &&
                ((r.RentDate <= rentDate && r.RentDate <= returnDate && r.ReturnDate >= rentDate && r.ReturnDate >= returnDate) ||
                (r.RentDate >= rentDate && r.RentDate <= returnDate) ||
                (r.ReturnDate >= rentDate && r.ReturnDate <= returnDate) ||
                (r.RentDate >= rentDate && r.RentDate <= returnDate) ||
                r.ReturnDate == null)
                ));
        }

        public IDataResult<decimal> GetTotalAmount(int id)
        {
            var rental = _rentalDal.Get(r => r.RentalID == id);
            var car = _carService.GetByID(rental.CarID);
            var days = (rental.ReturnDate.GetValueOrDefault() - rental.RentDate).Days;
            var totalAmount = days * car.Data.DailyPrice;
            return new SuccessDataResult<decimal>(totalAmount, "");
        }

        public IDataResult<List<Rental>> GetAllByCustomerID(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CustomerID == id));
        }

        public IResult CheckFindexScore(int customerID, int carID)
        {
            var result = _customerService.GetByID(customerID).Data.FindexScore >= _carService.GetByID(carID).Data.FindexScore;
            if (!result)
            {
                return new ErrorResult(Messages.NotEnoughFindexScore);
            }
            return new SuccessResult();
        }
    }
}
