using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult();
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<Rental> GetByID(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalID == id));
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        public IDataResult<RentalDetailDto> GetDtoByID(int id)
        {
            return new SuccessDataResult<RentalDetailDto> (_rentalDal.GetDtoByID(id));
        }
    }
}
