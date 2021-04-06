using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
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
using System.Linq.Expressions;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {// somut sınıf
        ICarDal _iCarDal;

        public CarManager(ICarDal iCarDal)
        {
            _iCarDal = iCarDal;
        }



        //[SecuredOperation("manager,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
           
            _iCarDal.Add(car);



            return new Result(true, Messages.CarAdded);
        }
        [SecuredOperation("manager,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _iCarDal.Delete(car);
            return new Result(true, Messages.CarsDeleted);
        }

        
        //[SecuredOperation("admin,manager,manager.getall")]
        [CacheAspect]
        [PerformanceAspect(2)]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>> (_iCarDal.GetAll(),Messages.CarsListed);
        }
        //[SecuredOperation("manager,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {


            _iCarDal.Update(car);
            return new Result(true, Messages.CarsUpdated);
        }
        //[SecuredOperation("manager,admin")]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails());
        }


        //[SecuredOperation("manager,admin")]
        [CacheAspect]
        //[PerformanceAspect(1)]
        public IDataResult<Car> GetById(int carId)
        {
            
            return new SuccessDataResult<Car> (_iCarDal.Get(c=>c.Id== carId));
        }


        //[SecuredOperation("manager,admin")]
        //public IDataResult<List<Car>> GetCarByBrandId(int id)
        //{
        //    return new SuccessDataResult<List<Car>> (_iCarDal.GetAll(c => c.BrandId == id));
        //}
        //[SecuredOperation("manager,admin")]
        //public IDataResult<List<Car>> GetCarByColorId(int id)
        //{
        //    return new SuccessDataResult<List<Car>> (_iCarDal.GetAll(c => c.ColorId == id));
        //}
        [SecuredOperation("manager,admin")]
        public IDataResult<List<Car>> GetCarDailyPrice(int min, int max)
        {
            return new SuccessDataResult<List<Car>> (_iCarDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car) //uygulamalarda tutarlılığı korumak için yapılan yöntemdir.
        {
            Add(car);
            if (car.DailyPrice < 38)
            {
                throw new Exception();
            }

            Add(car);
            return null;
        }

        IDataResult<List<CarDetailDto>> ICarService.GetCarByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails(c => c.ColorId == colorId));
        }

        IDataResult<List<CarDetailDto>> ICarService.GetCarByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails(b => b.BrandId == brandId));
        }

        //public IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        //{
        //    throw new NotImplementedException();
        //}

        //public IDataResult<List<CarDetailDto>> GetAllByColorId(int colorId)
        //{
        //    return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails(c => c.ColorId == colorId));
        //}

        //public IDataResult<List<CarDetailDto>> GetAllByBrandId(int brandId)
        //{
        //    return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetAll(c => c.BrandId == brandId));
        //}





        //public IDataResult<List<Car>> GetAllByColorId(int colorId)
        //{
        //    return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(c => c.ColorId == colorId));
        //}

        //public IDataResult<List<Car>> GetAllByBrandId(int brandId)
        //{
        //    return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(c => c.BrandId == brandId));
        //}


        //public IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        //{
        //    return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails(filter));
        //}

        //public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        //{
        //    return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails(b => b.BrandId == brandId));
        //}

        //public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        //{
        //    return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails(co => co.ColorId == colorId));
        //}



        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrand(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails(c => c.BrandId == brandId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColor(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails(c => c.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorAndByBrand(int colorId, int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails(c => c.ColorId == colorId && c.BrandId == brandId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsById(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails(x => x.Id == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails(car => car.Id == id));
        }
    }
}
