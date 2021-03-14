using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ICarImageService _carImageService;

        public CarManager(ICarDal carDal, ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [SecuredOperation("car.delete,admin")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        [SecuredOperation("car.update,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<Car> GetByID(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarID == id));
        }

        public IDataResult<List<Car>> GetAllByBrandID(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandID == id));
        }

        public IDataResult<List<Car>> GetAllByColorID(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorID == id));
        }

        public IDataResult<List<Car>> GetAllByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        public IDataResult<List<Car>> GetAllByModelYear(short min, short max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ModelYear >= min && c.ModelYear <= max));
        }

        [CacheAspect]
        public IDataResult<CarDetailDto> GetDtoByID(int id)
        {
            var result = _carDal.GetDtoByID(id);
            result.ImagePaths = _carImageService.GetImagesByCarID(id).Data.Select(c => c.ImagePath).ToList();
            return new SuccessDataResult<CarDetailDto>(result, Messages.CarDTOListed);
        }
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            var result = _carDal.GetCarDetails();
            foreach (var item in result)
            {
                item.ImagePaths = _carImageService.GetImagesByCarID(item.CarID).Data.Select(c => c.ImagePath).ToList();
            }
            return new SuccessDataResult<List<CarDetailDto>>(result, Messages.CarsDTOListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandName(string name)
        {
            var result = _carDal.GetCarDetails(c => c.BrandName == name);
            foreach (var item in result)
            {
                item.ImagePaths = _carImageService.GetImagesByCarID(item.CarID).Data.Select(c => c.ImagePath).ToList();
            }
            return new SuccessDataResult<List<CarDetailDto>>(result, Messages.CarsDTOListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorName(string name)
        {
            var result = _carDal.GetCarDetails(c => c.ColorName == name);
            foreach (var item in result)
            {
                item.ImagePaths = _carImageService.GetImagesByCarID(item.CarID).Data.Select(c => c.ImagePath).ToList();
            }
            return new SuccessDataResult<List<CarDetailDto>>(result, Messages.CarsDTOListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByDailyPrice(decimal min, decimal max)
        {
            var result = _carDal.GetCarDetails(c => c.DailyPrice >= min && c.DailyPrice <= max);
            foreach (var item in result)
            {
                item.ImagePaths = _carImageService.GetImagesByCarID(item.CarID).Data.Select(c => c.ImagePath).ToList();
            }
            return new SuccessDataResult<List<CarDetailDto>>(result, Messages.CarsDTOListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByModelYear(short min, short max)
        {
            var result = _carDal.GetCarDetails(c => c.ModelYear >= min && c.ModelYear <= max);
            foreach (var item in result)
            {
                item.ImagePaths = _carImageService.GetImagesByCarID(item.CarID).Data.Select(c => c.ImagePath).ToList();
            }
            return new SuccessDataResult<List<CarDetailDto>>(result, Messages.CarsDTOListed);;
        }
    }
}
