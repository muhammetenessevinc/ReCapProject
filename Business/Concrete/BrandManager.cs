using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
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

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {

            
            _brand.Add(brand);
            return new Result(true, Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            _brand.Delete(brand);
            return new Result(true, Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            //return _brand.GetAll();
            return new SuccessDataResult<List<Brand>>(_brand.GetAll(), Messages.BrandListed);
        }

        public IDataResult<Brand> GetCarsByBrandId(int brandId)
        {
            //return _brand.Get(b=>b.BrandId==brandId);
            return new SuccessDataResult<Brand>(_brand.Get(b => b.BrandId == brandId ));
        }

        public IResult Update(Brand brand)
        {
            _brand.Update(brand);
            return new Result(true, Messages.BrandUpdated);
        }

        //IDataResult<List<Brand>> IBrandService.GetCarsByBrandId(int brandId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
