using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        //[SecuredOperation("customer.add,admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            customer.FindexScore = 0;
            _customerDal.Add(customer);
            return new SuccessResult();
        }


        [SecuredOperation("customer.delete,admin")]
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult();
        }

        //[SecuredOperation("admin")]
        public IDataResult<Customer> GetByID(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.CustomerID == id));
        }

        [SecuredOperation("admin")]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        [SecuredOperation("admin")]
        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails());
        }

        //[SecuredOperation("customer.update,admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        public IDataResult<CustomerDetailDto> GetDtoByID(int id)
        {
            return new SuccessDataResult<CustomerDetailDto>(_customerDal.GetDtoByID(id));
        }

        public IDataResult<Customer> GetByUserID(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.UserID == id));
        }
    }
}
