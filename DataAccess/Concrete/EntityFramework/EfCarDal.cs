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
        //public List<CarDetailDto> GetCarDetail()
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                

                var result = from car in filter == null ? northwindContext.Cars :northwindContext.Cars.Where(filter)
                             join brand in northwindContext.Brands on car.BrandId equals brand.BrandId
                             join color in northwindContext.Colors on car.ColorId equals color.ColorId
                             select new CarDetailDto
                             {
                                 
                                 BrandName = brand.BrandName,
                                 DailyPrice = car.DailyPrice,
                                 ColorName = color.ColorName,
                                 Id=car.Id,
                                 ModelYear=car.ModelYear,
                                 BrandId=brand.BrandId,
                                 ColorId=color.ColorId,
                                 CarId=brand.BrandId,
                                 ImagePath = northwindContext.CarImages.Where(image => image.CarId == car.Id).ToList()

                             };
                return result.ToList();
            }
        }
    }
}
