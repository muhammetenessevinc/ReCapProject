using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, NorthwindContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                var result = from rental in northwindContext.Rentals
                             //join customer in northwindContext.Customers on user.UserId equals customer.CustomerId
                             join user in northwindContext.Users on rental.UserId equals user.UserId
                             join brand in northwindContext.Brands on rental.BrandId equals brand.BrandId

                             select new RentalDetailDto
                             {
                                 CarModel = brand.BrandName,
                                 FullName = user.FirstName+" "+user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate,
                                 RentalId = rental.RentalId,


                             };




                return result.ToList();
                
            }
        }
    }
}
