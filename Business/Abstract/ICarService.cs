using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {

        //IDataResult<List<Car>> GetCarByColorId(int id);
        //IDataResult<List<Car>> GetCarByBrandId(int id);


        IDataResult<List<CarDetailDto>> GetCarByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarByBrandId(int brandId);

        //IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<Car, bool>> filter = null);

        IDataResult<List<Car>> GetCarDailyPrice(int min, int max);
        IDataResult<List<CarDetailDto>> GetCarDetails();


        IDataResult<List<Car>> GetAll();// list kısmı aslında ıdataresultdaki T
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<Car> GetById(int id);
        IResult AddTransactionalTest(Car car);
        IDataResult<List<CarDetailDto>> GetCarDetailId(int id);

        //IDataResult<List<CarDetailDto>> GetAllByColorId(int colorId);
        //IDataResult<List<CarDetailDto>> GetAllByBrandId(int brandId);

        //IDataResult<List<Car>> GetAllByColorId(int colorId);
        //IDataResult<List<Car>> GetAllByBrandId(int brandId);






        IDataResult<List<CarDetailDto>> GetCarDetailsByBrand(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColor(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColorAndByBrand(int colorId, int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetailsById(int carId);
    }
}
