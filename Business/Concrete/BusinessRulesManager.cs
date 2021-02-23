using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BusinessRulesManager : IBusinessRules
    {
        public void NameRule(Car car)
        {
            if (car.Description.Length <2)
            {
                throw new Exception("Araç ismi minimum 2 karakterden oluşmalıdır.");
            }
        }

        public void PriceRule(Car car)
        {
            if (car.DailyPrice > 0)
            {
                Console.WriteLine("Aracınız Eklenmiştir.");
            }

            else
            {
                throw new Exception("Araçın günlük fiyatı 0'dan büyük olmalıdır.");
            }
        }
    }
}
