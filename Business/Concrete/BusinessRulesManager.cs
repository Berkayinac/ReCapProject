using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BusinessRulesManager : IBusinessRules
    {
        public IResult CarRented(Rental rental)
        {
            if (rental.ReturnDate != new DateTime(default))
            {
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }
        }

        public IResult NameRule(Car car)
        {
            if (car.Description.Length <2)
            {
                return new ErrorResult(Messages.NameRull);
            }
            return new SuccessResult();
        }

        public IResult PriceRule(Car car)
        { 
            if (car.DailyPrice < 0)
            {
               return new ErrorResult(Messages.PriceRull);
            }
            return new SuccessResult();
        }
    }
}
