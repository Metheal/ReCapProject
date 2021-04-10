using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetByID(int id);
        IDataResult<List<Rental>> GetAllByCustomerID(int id);
        IDataResult<List<Rental>> GetSingleByCarID(int carID, DateTime rentDate, DateTime returnDate);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IDataResult<RentalDetailDto> GetDtoByID(int id);
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<decimal> GetTotalAmount(int id);
    }
}
