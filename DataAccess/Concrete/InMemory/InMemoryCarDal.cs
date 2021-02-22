using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
                new Car {Id=1, BrandId=10, ColorId=100, DailyPrice=19500, ModelYear=1986, Descriptions="Efsane Kasa" },
                new Car {Id=2, BrandId=10, ColorId=105, DailyPrice=50000, ModelYear=2010, Descriptions="Keyfi Boyalı" },
                new Car {Id=3, BrandId=30, ColorId=109, DailyPrice=45000, ModelYear=2009, Descriptions="Yaşıtlarının En İyisi" },
                new Car {Id=4, BrandId=42, ColorId=153, DailyPrice=22350, ModelYear=1995, Descriptions="Hastasına" },
                new Car {Id=5, BrandId=28, ColorId=111, DailyPrice=95900, ModelYear=2015, Descriptions="Daha İyisi Yok" }
            };
        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);//single bütün veriyi dönüyor döndüğü ıd ile verideki ıd
            // eşitse
            _cars.Remove(carToDelete);// silme işlemini gerçekleştiriyor.
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars; // tümünü döndür
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c=>c.Id == carId).ToList();
        }

        public List<CarDetailDto> GetCarDetail()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {//cat to update = güncellenecek ürün
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Descriptions = car.Descriptions;
            carToUpdate.ModelYear = car.ModelYear;// burada gelen veri ile eski veriyi değiştir. sağ taraf yeni gelen data
        }
    }
}
