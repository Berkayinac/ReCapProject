using Business.Abstract;
using Business.Concrete;
using Core.Entities.Concrete;
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
            //ICarService carManager = new CarManager(new EfCarDal());
            IColorService colorManager = new ColorManager(new EfColorDal());
            IBrandService brandManager = new BrandManager(new EfBrandDal());

            IUserService userManager = new UserManager(new EfUserDal());
            ICustomerService customerManager = new CustomerManager(new EfCustomerDal());
            IRentalService rentalManager = new RentalManager(new EfRentalDal());


            Car addEntity = new Car() { BrandId = 1, ColorId = 3, DailyPrice = 20, Description = "KXL", ModelYear = "2020" };
            Car updateEntity = new Car { BrandId = 2, ColorId = 3, DailyPrice = 30, Description = "RX99", ModelYear = "2010" };

            Color addColor = new Color { ColorName = "Black" };
            Color updateColor = new Color { ColorId = 2, ColorName = "Black" };

            Brand addBrand = new Brand { BrandName = "Mustang" };
            Brand updateBrand = new Brand { BrandName = "Mercedes" };


            //User addUser = new User { FirstName = "Esra", LastName = "Gülen", Email = "esragülen@hotmail.com", Password = "esra1241" };
            //User updateUser = new User { FirstName = "Esra", LastName = "Gülen", Email = "esragülen@gmail.com", Password = "511esra" };

            Customer addCustomer = new Customer { UserId = 1, CompanyName = "A Firması" };
            Customer updateCustomer = new Customer { UserId = 1, CompanyName = "KY Şirketi" };

            Rental addRental = new Rental { CarId = 1, CustomerId = 2, RentDate = new DateTime(2021, 02, 25), ReturnDate = new DateTime(2021, 04, 25) };
            Rental updateRental = new Rental { CarId = 1, CustomerId = 2, RentDate = new DateTime(2021, 02, 25), ReturnDate = new DateTime(2021, 04, 25) };


            //carManager.Add(car1);
            //CarUpdateTest(carManager,updateEntity,1022);
            //CarDeleteTest(carManager,1022);
            //GetCarsByBrandId(carManager,6);
            //GetCarsByColorId(carManager,4);
            //GetAllCars(carManager);
            //CarDtoTest(carManager);

            //colorManager.Add(addColor);
            //ColorUpdateTest(colorManager, updateColor,2);
            //ColorDeleteTest(colorManager, 17);
            //GetAllColors(colorManager);

            //brandManager.Add(addBrand);
            //DeleteBrandTest(brandManager,1002);
            //UpdateBrandTest(brandManager, updateBrand,1002);
            //GetAllBrands(brandManager);

            //userManager.Add(addUser);
            //UserDeleteTest(userManager,12);
            //UserUpdateTest(userManager, updateUser,12);
            //GetAllUsers(userManager);
            //GetUsersByDtoTest(userManager);

            //customerManager.Add(addCustomer);
            //CustomerDeleteTest(customerManager, 12);
            //CustomerUpdateTest(customerManager, updateCustomer, 12);
            //GetAllCustomers(customerManager);

            rentalManager.Add(addRental);

            //RentalDeleteTest(rentalManager);
            //RentalUpdateTest(rentalManager, updateRental);
            //GetAllRentals(rentalManager);


            //Console.WriteLine(result.Message);
        }

        private static void GetUsersByDtoTest(IUserService userManager)
        {
            foreach (var userDto in userManager.GetUsersByDto().Data)
            {
                Console.WriteLine("{0}{1}{2}{3}{4}", userDto.FirstName, userDto.LastName, userDto.CompanyName, userDto.Email);
            }


        }

        private static void GetAllRentals(IRentalService rentalManager)
        {
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine("{0}{1}{2}{3}{4}", rental.RentalId, rental.CarId, rental.CustomerId, rental.RentDate, rental.ReturnDate);
            }
        }

        private static void RentalUpdateTest(IRentalService rentalManager, Rental updateRental)
        {
            var updatedResult = rentalManager.GetById(12).Data;
            updatedResult.CarId = updateRental.CarId;
            updatedResult.CustomerId = updateRental.CustomerId;
            updatedResult.RentalId = updateRental.RentalId;
            updatedResult.RentDate = updateRental.RentDate;
            updatedResult.ReturnDate = updateRental.ReturnDate;
            rentalManager.Update(updatedResult);
            Console.WriteLine((rentalManager.Update(updatedResult).Message));

        }

        private static void RentalDeleteTest(IRentalService rentalManager)
        {
            var deletedResult = rentalManager.GetById(12).Data;
            rentalManager.Delete(deletedResult);
        }

        private static void GetAllCustomers(ICustomerService customerManager)
        {
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CompanyName);
            }
        }

        private static void CustomerUpdateTest(ICustomerService customerManager, Customer updateCustomer, int customerId)
        {
            var updatedResult = customerManager.GetById(customerId).Data;
            updatedResult.CustomerId = updateCustomer.CustomerId;
            updatedResult.UserId = updateCustomer.UserId;
            updatedResult.CompanyName = updateCustomer.CompanyName;
            customerManager.Update(updatedResult);
        }

        private static void CustomerDeleteTest(ICustomerService customerManager, int customerId)
        {
            var deletedResult = customerManager.GetById(customerId).Data;
            customerManager.Delete(deletedResult);
        }

        //private static void GetAllUsers(IUserService userManager)
        //{
        //    foreach (var user in userManager.GetAll().Data)
        //    {
        //        Console.WriteLine("{0} | {1} | {2} | {3}", user.FirstName, user.LastName, user.Email, user.Password);
        //    }
        //}

        //private static void UserUpdateTest(IUserService userManager, User updateUser, int userId)
        //{
        //    var updatedResult = userManager.GetById(userId).Data;
        //    updatedResult.UserId = updateUser.UserId;
        //    updatedResult.FirstName = updateUser.FirstName;
        //    updatedResult.LastName = updateUser.LastName;
        //    updatedResult.Email = updateUser.Email;
        //    updatedResult.Password = updateUser.Password;
        //    userManager.Update(updatedResult);
        //}

        //private static void UserDeleteTest(IUserService userManager, int userId)
        //{
        //    var deletedResult = userManager.GetById(userId).Data;
        //    userManager.Delete(deletedResult);
        //}

        private static void UpdateBrandTest(IBrandService brandManager, Brand updateBrand, int brandId)
        {
            var result = brandManager.GetById(brandId).Data;
            result.BrandName = updateBrand.BrandName;
            brandManager.Update(result);
        }

        private static void DeleteBrandTest(IBrandService brandManager, int brandId)
        {
            var result = brandManager.GetById(brandId).Data;
            brandManager.Delete(result);
        }

        private static void ColorUpdateTest(IColorService colorManager, Color updateColor, int colorId)
        {
            var result = colorManager.GetById(colorId).Data;
            result.ColorId = updateColor.ColorId;
            result.ColorName = updateColor.ColorName;
            colorManager.Update(result);
        }

        private static void ColorDeleteTest(IColorService colorManager, int colorId)
        {
            var deleteColor = colorManager.GetById(colorId).Data;
            colorManager.Delete(deleteColor);
        }

        private static void CarUpdateTest(ICarService carManager, Car updateEntity, int carId)
        {
            var result = carManager.GetById(carId).Data;
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
            var deleteResult = carManager.GetById(carId).Data;
            carManager.Delete(deleteResult);
        }

        private static void CarDtoTest(ICarService carManager)
        {
            Console.WriteLine("---------------DTO---------------");

            foreach (var carDto in carManager.GetCarsByDto().Data)
            {
                Console.WriteLine("{0} | {1} | {2} | {3}", carDto.BrandName, carDto.CarDescription, carDto.ColorName, carDto.DailyPrice);
            }
        }

        private static void GetCarsByColorId(ICarService carManager, int id)
        {
            Console.WriteLine("---------------GetCarsByColorId----------------");

            foreach (var car in carManager.GetCarsByColorId(id).Data)
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void GetCarsByBrandId(ICarService carManager, int id)
        {
            Console.WriteLine("--------------GetCarsByBrandId-----------------");

            foreach (var car in carManager.GetCarsByBrandId(id).Data)
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void GetAllBrands(IBrandService brandManager)
        {
            Console.WriteLine("---------------GetAllBrands----------------");
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void GetAllColors(IColorService colorManager)
        {
            Console.WriteLine("---------------GetAllColors----------------");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void GetAllCars(ICarService carManager)
        {
            Console.WriteLine("---------------GetAllCars----------------");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
