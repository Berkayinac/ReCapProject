using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Abstract;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarDal carDal = new InMemoryCarDal();
            CarManager carManager = new CarManager(carDal);
            Car car = new Car { CarId = , BrandId = 1, ColorId = 1, DailyPrice = 1451234, Description = "M4 Serisi", ModelYear = new DateTime(2010,1,20) };
            Car car1 = new Car { CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 1521497, ModelYear = new DateTime(2015, 12, 10), Description = "M235i xDrive" };
            carManager.Add(car);
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.Description);
            }

        }
    }
}
