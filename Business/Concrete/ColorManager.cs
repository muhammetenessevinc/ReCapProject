using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _color;

        public ColorManager(IColorDal color)
        {
            _color = color;
        }
        [SecuredOperation("manager,admin")]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Add(Color color)
        {
            _color.Add(color);
            return new Result(true, Messages.ColorAdded);
        }


        [SecuredOperation("manager,admin")]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Delete(Color color)
        {
            _color.Delete(color);
            return new Result(true, Messages.ColorDeleted);
        }


        //[SecuredOperation("admin,manager,manager.getall")]
        [CacheAspect]
        public IDataResult<List<Color>> GetAll()
        {
            //return _color.GetAll();
            return new SuccessDataResult<List<Color>>(_color.GetAll(), Messages.ColorListed);
        }


        [SecuredOperation("admin,manager,manager.getall")]
        [CacheAspect]
        public IDataResult<Color> GetCarsByColorId(int colorId)
        {
            //return _color.Get(c=>c.ColorId==colorId);
            return new SuccessDataResult<Color>(_color.Get(c => c.ColorId == colorId));
        }


        [SecuredOperation("manager,admin")]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Update(Color color)
        {
            _color.Update(color);
            return new Result(true, Messages.ColorUpdated);
        }
    }
}
