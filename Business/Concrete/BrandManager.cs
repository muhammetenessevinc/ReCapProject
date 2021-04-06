using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brand;

        public BrandManager(IBrandDal brand)
        {
            _brand = brand;
        }
        //[SecuredOperation("manager,admin")]
        [CacheRemoveAspect("IBrandService.Get")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {

            
            _brand.Add(brand);
            return new Result(true, Messages.BrandAdded);
        }


        [SecuredOperation("manager,admin")]
        [CacheRemoveAspect("IBrandService.Get")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Delete(Brand brand)
        {
            _brand.Delete(brand);
            return new Result(true, Messages.BrandDeleted);
        }


        //[SecuredOperation("admin,manager,manager.getall")]
        [CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
            //return _brand.GetAll();
            return new SuccessDataResult<List<Brand>>(_brand.GetAll(), Messages.BrandListed);
        }


        [SecuredOperation("manager,admin")]
        [CacheAspect]
        public IDataResult<Brand> GetCarsByBrandId(int brandId)
        {
            //return _brand.Get(b=>b.BrandId==brandId);
            return new SuccessDataResult<Brand>(_brand.Get(b => b.BrandId == brandId ));
        }


        //[SecuredOperation("manager,admin")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Update(Brand brand)
        {
            _brand.Update(brand);
            return new Result(true, Messages.BrandUpdated);
        }

        
    }
}
