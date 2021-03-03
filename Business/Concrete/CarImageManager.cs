using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile formFile, CarImage carImage, string path)
        {
            var result = BusinessRules.Run(CheckIfCarImageLimitExceeded(carImage));

            if (result != null)
            {
                return result;
            }

            var fileHelper = FileHelper.WriteFile(formFile, path);

            if (!fileHelper.Success)
            {
                return new ErrorResult(fileHelper.Message);
            }
            carImage.ImagePath = fileHelper.Message;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult($"Car Image eklendi {carImage.ImagePath}");
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<CarImage> GetByID(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageID == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IResult Update(IFormFile formfile, CarImage carImage, string path)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }


        public IDataResult<List<CarImage>> GetImagesByCarID(int id)
        {
            var result = _carImageDal.GetAll(c => c.CarID == id);
            if (!result.Any())
            {
                var defaultImage = Path.Combine(Path.DirectorySeparatorChar.ToString(), "Images", "default.jpg");
                return new SuccessDataResult<List<CarImage>>(new List<CarImage> { new CarImage { CarID = id, ImagePath = defaultImage } }, "default image");
            }
            return new SuccessDataResult<List<CarImage>>(result);
        }
        private IResult CheckIfCarImageLimitExceeded(CarImage carImage)
        {
            if (_carImageDal.GetAll(c => c.CarID == carImage.CarID).Count >= 5)
            {
                return new ErrorResult("Aracin 5ten fazla resmi olamaz");
            }

            return new SuccessResult();
        }

    }
}
