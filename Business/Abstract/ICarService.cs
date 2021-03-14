using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetAllByBrandID(int id);
        IDataResult<List<Car>> GetAllByColorID(int id);
        IDataResult<List<Car>> GetAllByDailyPrice(decimal min, decimal max);
        IDataResult<List<Car>> GetAllByModelYear(short min, short max);
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandName(string name);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColorName(string name);
        IDataResult<List<CarDetailDto>> GetCarDetailsByDailyPrice(decimal min, decimal max);
        IDataResult<List<CarDetailDto>> GetCarDetailsByModelYear(short min, short max);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<Car> GetByID(int id);
        IDataResult<CarDetailDto> GetDtoByID(int id);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
    }
}
