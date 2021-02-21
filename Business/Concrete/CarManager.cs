using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IResult Add(Car car)
        {
            if (car.DailyPrice <= 0)
            {
                return new ErrorResult(Messages.DailyPriceInvalid);
            }
            else if (car.CarName.Length < 3)
            {
                return new ErrorResult(Messages.CarInvalidName);
            }
            else
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }

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

        public IDataResult<CarDetailDto> GetDtoByID(int id)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetDtoByID(id), Messages.CarDTOListed);
        }
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 8)
            {
                return new ErrorDataResult<List<CarDetailDto>>("Sistem bakimda");
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarsDTOListed);
        }
    }
}
