using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Add(Car car)
        {
            _businessRules.NameRule(car);
            _businessRules.PriceRule(car);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            // iş kuralları
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
           return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id),Messages.CarGeted);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId),Messages.CarsByBrandsListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId),Messages.CarsByColorsListed);
        }

        public IDataResult<List<CarDto>> GetCarsByDto()
        {
            return new SuccessDataResult<List<CarDto>>(_carDal.GetByDtoList(),Messages.CarDtoListed);
        }

        public IResult Update(Car car)
        {
            // iş kuralları
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
