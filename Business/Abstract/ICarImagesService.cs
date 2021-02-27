using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImagesService
    {
        IDataResult<List<CarImages>> GetImagesByCarId(int id);
        IDataResult<List<CarImages>> GetAll();
        IResult Add(IFormFile file, CarImages carImages);
        IResult Update(IFormFile file, CarImages carImages);
        IResult Delete(CarImages carImages);
        IDataResult<CarImages> Get(int id);

    }
}
