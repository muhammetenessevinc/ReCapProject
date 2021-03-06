using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {

        IDataResult<List<Car>> GetCarByColorId(int id);
        IDataResult<List<Car>> GetCarByBrandId(int id);

        IDataResult<List<Car>> GetCarDailyPrice(int min, int max);
        IDataResult<List<CarDetailDto>> GetCarDetails();


        IDataResult<List<Car>> GetAll();// list kısmı aslında ıdataresultdaki T
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<Car> GetById(int carId);
        IResult AddTransactionalTest(Car car);

    }
}
