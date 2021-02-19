using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
   public class InMemoryCarDal : ICarDal
    {
        List<Color> colors;
        List<Brand> brands;
        List<Car> cars;
        

        public InMemoryCarDal()
        {
            colors = new List<Color>
            {
                new Color{ColorId=1,ColorName="Siyah"},
                new Color{ColorId=2,ColorName="Beyaz"},
                new Color{ColorId=3,ColorName="Gri"}
            };

            brands = new List<Brand>
            {
                new Brand{BrandId =1, BrandName="BMW"},
                new Brand{BrandId =2, BrandName="Audı"},
            };

            cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=1521497,ModelYear=new DateTime(2015,12,10),Description="M235i xDrive"},
                new Car{CarId=2,BrandId=1,ColorId=3,DailyPrice=2051252,ModelYear=new DateTime(2017,3,21),Description="M5 xDrive Sedan"},
                new Car{CarId=3,BrandId=1,ColorId=2,DailyPrice=1862960,ModelYear=new DateTime(2018,1,28),Description="M8 Cabrio xDrive"},
                new Car{CarId=4,BrandId=2,ColorId=2,DailyPrice=1679231,ModelYear=new DateTime(2019,6,3),Description="A4 Sedan"},
                new Car{CarId=5,BrandId=2,ColorId=1,DailyPrice=1432187,ModelYear=new DateTime(2016,8,13),Description="A6 Avant"},
            };
        }

        public void Add(Car car)
        {
            cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = cars.SingleOrDefault(c => c.CarId == car.CarId);
            cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return cars;
        }

        public Car GetById(int id)
        {
            var entity = cars.SingleOrDefault(c => c.CarId == id);
            return entity;
        }

        public void Update(Car car)
        {
            Car carToUpdate = cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
