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
        IDataResult<List<Car>> GetAllDailyPrice(decimal min, decimal max);
        IDataResult<List<Car>> GetAllByModelYear(short min, short max);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<Car> Get(int id);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
    }
}
