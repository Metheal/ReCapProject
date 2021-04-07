using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;
        IRentalService _rentalService;

        public PaymentManager(IPaymentDal paymentDal, IRentalService rentalService)
        {
            _paymentDal = paymentDal;
            _rentalService = rentalService;
        }

        public IResult Add(Payment payment)
        {
            payment.TotalAmount = _rentalService.GetTotalAmount(payment.RentalID).Data;
            _paymentDal.Add(payment);
            return new SuccessResult();
        }

        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);
            return new SuccessResult();
        }

        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll());
        }

        public IDataResult<Payment> Get(int id)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(p => p.PaymentID == id));
        }

        public IDataResult<List<Payment>> GetAllByRentalID(int id)
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(p => p.RentalID == id));
        }

        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);
            return new SuccessResult();
        }
    }
}
