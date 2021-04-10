using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IHostEnvironment _hostEnvironment;
        public CarImageManager(ICarImageDal carImageDal, IHostEnvironment hostEnvironment)
        {
            _carImageDal = carImageDal;
            _hostEnvironment = hostEnvironment;
        }
        
        [SecuredOperation("carimage.add,admin")]
        //[ValidationAspect(typeof(ImageValidator))] // didn't work for now so I move on with a temporary solution
        // I suppose it's because it cannot create an instance of type I gave it. it was IFormFile
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageLimitExceeded(carImage), CheckIfImageIsValid(formFile));
            var imagetype = formFile.ContentType;
            if (result != null)
            {
                return result;
            }

            var root = _hostEnvironment.ContentRootPath;
            var wwwroot = Path.Combine(root, "wwwroot");
            var path = Path.Combine(wwwroot, "Images");
            var fileHelper = FileHelper.WriteFile(formFile, path);

            if (!fileHelper.Success)
            {
                return new ErrorResult(fileHelper.Message);
            }

            carImage.ImagePath = fileHelper.Data;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult($"{Messages.CarImageAdded}: {carImage.ImagePath}");
        }

        [SecuredOperation("carimage.delete,admin")]
        public IResult Delete(CarImage carImage)
        {
            var root = _hostEnvironment.ContentRootPath;
            var wwwroot = Path.Combine(root, "wwwroot");
            var sourcePath = $"{wwwroot}{_carImageDal.Get(ci => ci.CarImageID == carImage.CarImageID).ImagePath}";
            var fileHelper = FileHelper.DeleteFile(sourcePath);

            if (!fileHelper.Success)
            {
                return new ErrorResult(fileHelper.Message);
            }

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        [CacheAspect]
        public IDataResult<CarImage> GetByID(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageID == id));
        }

        [CacheAspect]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        [SecuredOperation("carimage.update,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfImageIsValid(formFile));

            if (result != null)
            {
                return result;
            }

            var root = _hostEnvironment.ContentRootPath;
            var wwwroot = Path.Combine(root, "wwwroot");
            var path = Path.Combine(wwwroot, "Images");
            var sourcePath = $"{wwwroot}{_carImageDal.Get(ci => ci.CarImageID == carImage.CarImageID).ImagePath}";
            var fileHelper = FileHelper.UpdateFile(sourcePath, formFile, path);

            if (!fileHelper.Success)
            {
                return new ErrorResult(fileHelper.Message);
            }

            carImage.ImagePath = fileHelper.Data;
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);

            return new SuccessResult(Messages.CarImageUpdated);
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
            var result = _carImageDal.GetAll(c => c.CarID == carImage.CarID).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();
        }

        private IResult CheckIfImageIsValid(IFormFile formFile)
        {
            var result = formFile.ContentType.ToString().StartsWith("image");
            if (!result)
            {
                return new ErrorResult(Messages.NotAnImage);
            }
            return new SuccessResult();
        }


    }
}
