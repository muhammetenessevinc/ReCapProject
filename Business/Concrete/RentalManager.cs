using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        //public IDataResult<Rental> CheckReturnDate(int carId)
        //{
        //    List<Rental> result = _rentalDal.GetAll(x => x.BrandId == carId && x.ReturnDate == null);
        //    if (result.Count > 0) return new ErrorDataResult<Rental>(Messages.RentalUndeliveredCar);
        //    return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.BrandId == carId));
        //}


        //[SecuredOperation("manager,admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {

            //_rentalDal.Add(rental);
            //return new Result(true, Messages.RentalAdded);


            //var result = _rentalDal.GetAll(r => r.CarId == rental.CarId && (r.ReturnDate == null)).Any();

            //if (result)
            //{
            //    return new ErrorResult(Messages.ErrorRent);

            //}
            //_rentalDal.Add(rental);

            //return new SuccessResult(Messages.RentalAdded);

            var rentCar = _rentalDal.Get(c => c.CarId == rental.CarId && c.ReturnDate < DateTime.Today);
            if (rentCar != null)
            {
                return new ErrorResult("Bu araç kiralanamaz");
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult("Araç kiralanmıştır.");
            }




        }
        [SecuredOperation("manager,admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }
        //[SecuredOperation("admin,manager,manager.getall")]
        //[CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        //[SecuredOperation("admin,manager,manager.getall")]
        [CacheAspect]
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == id));
        }
        [SecuredOperation("manager,admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult IsRentable(Rental rental)
        {
            var result = _rentalDal.GetAll();
            if (result.Where(r => r.CarId == rental.CarId
                    && r.ReturnDate >= rental.RentDate
                    && r.RentDate <= rental.ReturnDate).Any())
                return new ErrorResult(Messages.RentalInValid);
            return new SuccessResult(Messages.CarIsRentable);
        }

        
    }
}
