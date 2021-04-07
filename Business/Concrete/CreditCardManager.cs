using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        [ValidationAspect(typeof(CreditCardValidator))]
        public IResult Add(CreditCard creditCard, Boolean save)
        {
            if (save == true)
            {
                var result = BusinessRules.Run(CheckIfCreditCardNotRegistered(creditCard));
                if (result == null)
                    _creditCardDal.Add(creditCard);
            }
            return new SuccessResult();
        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult();
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll());
        }

        // need a securedoperation aspect otherwise anyone can see any cc info
        public IDataResult<List<CreditCard>> GetAllByCustomerID(int customerID)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(c => c.CustomerID == customerID));

        }

        public IDataResult<CreditCard> GetByID(int id)
        {
            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(c => c.CreditCardID == id));
        }

        [ValidationAspect(typeof(CreditCardValidator))]
        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult();
        }

        private IResult CheckIfCreditCardNotRegistered(CreditCard creditCard)
        {
            var result = _creditCardDal.Get(c => c.CreditCardNumber == creditCard.CreditCardNumber);

            if (result == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Kredi Karti zaten mevcut");
        }
    }
}
