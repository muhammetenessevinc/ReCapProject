using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, NorthwindContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail()
        {
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                var result = from c in northwindContext.Cars
                             join b in northwindContext.Brands
                             on c.BrandId equals b.BrandId
                             join d in northwindContext.Colors
                             on c.ColorId equals d.ColorId
                             select new CarDetailDto {BrandId = b.BrandId, BrandName=b.BrandName,
                                 ColorName= d.ColorName, CarName=c.Descriptions };
                return result.ToList();
            }
        }
    }
}
