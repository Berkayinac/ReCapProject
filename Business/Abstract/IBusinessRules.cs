using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IBusinessRules
    {
        IResult NameRule(Car car);
        IResult PriceRule(Car car);
        IResult CarRented(Rental rental);
    }
}
