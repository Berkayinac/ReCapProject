using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBusinessRules _businessRules;

        public CarManager(ICarDal carDal, IBusinessRules businessRules)
        {
            _carDal = carDal;
            _businessRules = businessRules;
        }

        public void Add(Car car)
        {
            _businessRules.NameRule(car);
            _businessRules.PriceRule(car);
            _carDal.Add(car);
        }

        public void Delete(Car car)
        {
            // iş kuralları
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            // iş kuralları
           return _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _carDal.Get(c => c.CarId == id);
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public void Update(Car car)
        {
            // iş kuralları
            _carDal.Update(car);
        }
    }
}
