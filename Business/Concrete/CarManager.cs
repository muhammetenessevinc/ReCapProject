using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
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

        //public void Add(Car car)
        //{
        //    _iCarDal.Add(car);
        //}



        public IResult Add(Car car)
        {
            if (car.DailyPrice < 0)
            {
                return new ErrorResult(Messages.CarNameInvalid);   
            }
            _iCarDal.Add(car);



            return new Result(true, Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _iCarDal.Delete(car);
            return new Result(true, Messages.CarsDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>> (_iCarDal.GetAll(),Messages.CarsListed);
        }

        public IResult Update(Car car)
        {


            _iCarDal.Update(car);
            return new Result(true, Messages.CarsUpdated);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetail());
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car> (_iCarDal.Get(c=>c.Id== carId));
        }


        
        public IDataResult<List<Car>> GetCarByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>> (_iCarDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarByColorId(int id)
        {
            return new SuccessDataResult<List<Car>> (_iCarDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<List<Car>> GetCarDailyPrice(int min, int max)
        {
            return new SuccessDataResult<List<Car>> (_iCarDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        
    }
}
