using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IBusinessRules
    {
        void NameRule(Car car);
        void PriceRule(Car car);
    }
}
