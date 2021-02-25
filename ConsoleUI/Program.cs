using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carManager = new CarManager(new EfCarDal(), new BusinessRulesManager());
            IColorService colorManager = new ColorManager(new EfColorDal());
            IBrandService brandManager = new BrandManager(new EfBrandDal());

            Car addEntity = new Car() { BrandId = 1, ColorId = 3, DailyPrice = 20, Description = "KXL", ModelYear = "2020" };
            Car updateEntity = new Car { BrandId = 2, ColorId = 3, DailyPrice = 30, Description = "RX99", ModelYear = "2010" };

            Color addColor = new Color { ColorName = "Black" };
            Color updateColor = new Color { ColorId = 2, ColorName = "Black" };

            Brand addBrand = new Brand { BrandName = "Mustang" };
            Brand updateBrand = new Brand { BrandName = "Mercedes" };


            //GetCarsByBrandId(carManager);
            //GetCarsByColorId(carManager);

            //GetAllBrands(brandManager);
            //CarDtoTest(carManager);

            //carManager.Add(car1);
            //CarUpdateTest(carManager,updateEntity,1022);
            //CarDeleteTest(carManager,1022);
            //GetAllCars(carManager);

            //colorManager.Add(addColor);
            //ColorUpdateTest(colorManager, updateColor,2);
            //ColorDeleteTest(colorManager, 17);
            //GetAllColors(colorManager);

            //brandManager.Add(addBrand);
            //DeleteBrandTest(brandManager,1002);
            //UpdateBrandTest(brandManager, updateBrand,1002);
            //GetAllBrands(brandManager);
        }

        private static void UpdateBrandTest(IBrandService brandManager, Brand updateBrand, int brandId)
        {
            var result = brandManager.GetById(brandId);
            result.BrandName = updateBrand.BrandName;
            brandManager.Update(result);
        }

        private static void DeleteBrandTest(IBrandService brandManager,int brandId)
        {
            var result = brandManager.GetById(brandId);
            brandManager.Delete(result);
        }

        private static void ColorUpdateTest(IColorService colorManager, Color updateColor, int colorId)
        {
            var result = colorManager.GetById(colorId);
            result.ColorId = updateColor.ColorId;
            result.ColorName = updateColor.ColorName;
            colorManager.Update(result);
        }

        private static void ColorDeleteTest(IColorService colorManager, int colorId)
        {
            var deleteColor = colorManager.GetById(colorId);
            colorManager.Delete(deleteColor);
        }

        private static void CarUpdateTest(ICarService carManager, Car updateEntity, int carId)
        {
            var result = carManager.GetById(carId);
            result.BrandId = updateEntity.BrandId;
            result.ColorId = updateEntity.ColorId;
            result.DailyPrice = updateEntity.DailyPrice;
            result.Description = updateEntity.Description;
            result.ModelYear = updateEntity.ModelYear;

            carManager.Update(result);
        }

        private static void CarDeleteTest(ICarService carManager, int carId)
        {
            // referansı alıp silme.
            var deleteResult = carManager.GetById(carId);
            carManager.Delete(deleteResult);
        }

        private static void CarDtoTest(ICarService carManager)
        {
            Console.WriteLine("---------------DTO---------------");

            foreach (var carDto in carManager.GetCarsByDto())
            {
                Console.WriteLine("{0} | {1} | {2} | {3}", carDto.BrandName, carDto.CarDescription, carDto.ColorName, carDto.DailyPrice);
            }
        }

        private static void GetCarsByColorId(ICarService carManager)
        {
            Console.WriteLine("---------------GetCarsByColorId----------------");

            foreach (var car in carManager.GetCarsByColorId(3))
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void GetCarsByBrandId(ICarService carManager)
        {
            Console.WriteLine("--------------GetCarsByBrandId-----------------");

            foreach (var car in carManager.GetCarsByBrandId(12))
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void GetAllBrands(IBrandService brandManager)
        {
            Console.WriteLine("---------------GetAllBrands----------------");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void GetAllColors(IColorService colorManager)
        {
            Console.WriteLine("---------------GetAllColors----------------");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void GetAllCars(ICarService carManager)
        {
            Console.WriteLine("---------------GetAllCars----------------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
