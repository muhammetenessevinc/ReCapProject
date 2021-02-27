using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Helpers;
using System.IO;
using System.Linq;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImagesService
    {
        ICarImagesDal _carImagesDal;

        public CarImagesManager(ICarImagesDal carImagesDal)
        {
            _carImagesDal = carImagesDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file,CarImages carImages)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimit(carImages.CarId));
            if (result != null)
            {
                return result;
            }
            carImages.ImagePath = FileHelper.Add(file);
            carImages.Date = DateTime.Now;
            _carImagesDal.Add(carImages);
            return new SuccessResult();
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImages carImages)
        {
            IResult result = BusinessRules.Run(CarImageDelete(carImages));
            if (result != null)
            {
                return result;
            }
            _carImagesDal.Delete(carImages);
            return new SuccessResult();
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<CarImages> Get(int id)
        {
            return new SuccessDataResult<CarImages>(_carImagesDal.Get(p => p.Id == id));
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll());
        }

        public IDataResult<List<CarImages>> GetImagesByCarId(int id)
        {
            return new SuccessDataResult<List<CarImages>>(CheckIfCarImageNull(id));
        }


        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImages carImages)
        {
            carImages.ImagePath = FileHelper.Update(_carImagesDal.Get(p => p.Id == carImages.Id).ImagePath, file);
            carImages.Date = DateTime.Now;
            _carImagesDal.Update(carImages);
            return new SuccessResult();
        }


        private IResult CheckIfImageLimit(int carid)
        {
            var carImagecount = _carImagesDal.GetAll(p => p.CarId == carid).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.ImageLimit);
            }

            return new SuccessResult();
        }

        private IResult CarImageDelete(CarImages carImage)
        {
            try
            {
                File.Delete(carImage.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

        private List<CarImages> CheckIfCarImageNull(int id)
        {
            string path = @"\Images\logo.jpg";
            var result = _carImagesDal.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
                return new List<CarImages> { new CarImages { CarId = id, ImagePath = path, Date = DateTime.Now } };
            }
            return _carImagesDal.GetAll(p => p.CarId == id);
        }
    }
}
