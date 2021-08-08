using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        [SecuredOperation("user.delete,admin")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }

        //[SecuredOperation("admin")]
        public IDataResult<User> GetByID(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserID == id));
        }

        [SecuredOperation("admin")]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        //[SecuredOperation("user.update,admin")]
        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            var result = GetByID(user.UserID);
            user.Status = result.Data.Status;
            user.PasswordHash = result.Data.PasswordHash;
            user.PasswordSalt = result.Data.PasswordSalt;
            _userDal.Update(user);
            return new SuccessResult();
        }

        public IDataResult<User> GetByEMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.EMail == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
           return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
                   
        }
    }
}
