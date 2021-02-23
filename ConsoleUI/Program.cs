using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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
            ICarService carManager = new CarManager(new EfCarDal(),new BusinessRulesManager());
            IColorService colorManager = new ColorManager(new EfColorDal());
            IBrandService brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("---------------GetAll----------------");

            Console.WriteLine("---------------GetAllCars----------------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("---------------GetAllColors----------------");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine("---------------GetAllBrands----------------");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }


            Console.WriteLine("--------------GetCarsByBrandId-----------------");

            foreach (var car in carManager.GetCarsByBrandId(15))
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("---------------GetCarsByColorId----------------");

            foreach (var car in carManager.GetCarsByColorId(3))
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("---------------Yeni bir araba ekleme----------------");

            Car car1 = new Car() { BrandId = 1, ColorId = 3, DailyPrice = 20, Description = "KXL", ModelYear = new DateTime(2020, 12, 10 ) };

            carManager.Add(car1);

            Console.WriteLine("---------------GetAllCars----------------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
