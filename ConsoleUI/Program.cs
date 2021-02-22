using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //cartest();
            //brandtest();
            //colortest();


            //cartest1();

            //UserTest();


            //CustomerTest();



            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental
            {
                //Id = 3,
                CarId = 5,
                CustomerId = 3,
                RentDate = DateTime.Now,
                ReturnDate = null
            };
            IResult result = rentalManager.Add(rental);
            if (!result.Success) Console.WriteLine(result.Message);
            //rentalManager.Update(rental);
            //rentalManager.Delete(rental);
            rentalManager.GetAll().Data.ForEach(r => Console.WriteLine(r.CarId + " " + r.RentDate));
            //foreach (var rental in rentalManager.GetAll().Data)
            //{
            //    Console.WriteLine(rental.CarId+"  "+rental.RentDate);
            //}






        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CompanyName);
            }
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());


            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.FirstName);
            }
        }

        private static void cartest1()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + car.CarName + car.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        //private static void colortest()
        //{
        //    ColorManager colorManager = new ColorManager(new EfColorDal());
        //    Console.WriteLine("------ARAÇ RENK ID VE MARKA ADI BİLGİSİ------");
        //    Console.WriteLine("---------------------------------------------");
        //    Console.WriteLine("Renk Id     Renk Adı");
        //    Console.WriteLine("-------     --------");
        //    foreach (var color in colorManager.GetAll())
        //    {
        //        Console.WriteLine(color.ColorId + "       --->  " + color.ColorName);
        //    }
        //}

        //private static void brandtest()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    Console.WriteLine("------ARAÇ MARKA ID VE MARKA ADI BİLGİSİ------");
        //    Console.WriteLine("---------------------------------------------");
        //    Console.WriteLine("Marka Id     Marka Adı");
        //    Console.WriteLine("--------     ---------");
        //    foreach (var brand in brandManager.GetAll())
        //    {
        //        Console.WriteLine(brand.BrandId + "       --->  " + brand.BrandName);
        //    }
        //}

        //private static void cartest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());

        //    Console.WriteLine("------GÜNLÜK ARAÇ KİRA FİYATLARI------");
        //    Console.WriteLine("---------------------------------------------");
        //    Console.WriteLine("Marka Id     Renk Id     Model Yılı          Açıklama              Günlük ücret");
        //    Console.WriteLine("--------     -------     ----------          --------              ------------");
        //    foreach (var car in carManager.GetAll())
        //    {
        //        Console.WriteLine(car.BrandId + "           -   " + car.ColorId + "        -   " + car.ModelYear + "           -   " + car.Descriptions + "          --->     " + car.DailyPrice + " TL");
        //    }
        //}
    }
}
