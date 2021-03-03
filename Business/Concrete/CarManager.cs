using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {// somut sınıf
        ICarDal _iCarDal;

        public CarManager(ICarDal iCarDal)
        {
            _iCarDal = iCarDal;
        }

     

        [SecuredOperation("Manager,Admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
           
            _iCarDal.Add(car);



            return new Result(true, Messages.CarAdded);
        }
        [SecuredOperation("Manager,Admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Delete(Car car)
        {
            _iCarDal.Delete(car);
            return new Result(true, Messages.CarsDeleted);
        }
        [SecuredOperation("Admin,Manager,Manager.getall")]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>> (_iCarDal.GetAll(),Messages.CarsListed);
        }
        [SecuredOperation("Manager,Admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {


            _iCarDal.Update(car);
            return new Result(true, Messages.CarsUpdated);
        }
        [SecuredOperation("Manager,Admin")]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetail());
        }
        [SecuredOperation("Manager,Admin")]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car> (_iCarDal.Get(c=>c.Id== carId));
        }


        [SecuredOperation("Manager,Admin")]
        public IDataResult<List<Car>> GetCarByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>> (_iCarDal.GetAll(c => c.BrandId == id));
        }
        [SecuredOperation("Manager,Admin")]
        public IDataResult<List<Car>> GetCarByColorId(int id)
        {
            return new SuccessDataResult<List<Car>> (_iCarDal.GetAll(c => c.ColorId == id));
        }
        [SecuredOperation("Manager,Admin")]
        public IDataResult<List<Car>> GetCarDailyPrice(int min, int max)
        {
            return new SuccessDataResult<List<Car>> (_iCarDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        
    }
}
