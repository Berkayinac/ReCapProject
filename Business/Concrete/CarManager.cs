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

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {

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
            // iş kuralları
           return _carDal.GetById(id);
        }

        public void Update(Car car)
        {
            // iş kuralları
            _carDal.Update(car);
        }
    }
}
