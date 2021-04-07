using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IResult Add(CreditCard creditCard, Boolean save);
        IResult Delete(CreditCard creditCard);
        IResult Update(CreditCard creditCard);
        IDataResult<List<CreditCard>> GetAll();
        IDataResult<List<CreditCard>> GetAllByCustomerID(int customerID);
        IDataResult<CreditCard> GetByID(int id);

    }
}
