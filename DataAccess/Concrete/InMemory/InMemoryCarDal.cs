﻿using DataAccess.Abstract;
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
        List<Color> colors;
        List<Brand> brands;
        List<Car> cars;
        

        public InMemoryCarDal()
        {
            colors = new List<Color>
            {
                new Color{Id=1,Name="Siyah"},
                new Color{Id=2,Name="Beyaz"},
                new Color{Id=3,Name="Gri"}
            };

            brands = new List<Brand>
            {
                new Brand{Id =1, Name="BMW"},
                new Brand{Id =2, Name="Audı"},
            };

            cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=1521,ModelYear="2015",Description="M235i xDrive"},
                new Car{CarId=2,BrandId=1,ColorId=3,DailyPrice=2051,ModelYear="2016",Description="M5 xDrive Sedan"},
                new Car{CarId=3,BrandId=1,ColorId=2,DailyPrice=1862,ModelYear="2017",Description="M8 Cabrio xDrive"},
                new Car{CarId=4,BrandId=2,ColorId=2,DailyPrice=1679,ModelYear="2016",Description="A4 Sedan"},
                new Car{CarId=5,BrandId=2,ColorId=1,DailyPrice=1432,ModelYear="2014",Description="A6 Avant"},
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

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByDtoList(Car car)
        {
            throw new NotImplementedException();
        }

        public List<CarDto> GetByDtoList()
        {
            throw new NotImplementedException();
        }

        public List<CarDto> GetByDtoList(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
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
