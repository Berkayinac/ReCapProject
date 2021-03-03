using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.DailyPrice).GreaterThan(100);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(0).When(c => c.ColorId == 7);
            //RuleFor(c => c.Description).Must(StartWithB).WithMessage("Araç bilgisi B harfi ile başlamalı");
        }

        private bool StartWithB(string arg)
        {
            return arg.StartsWith("B");
        }
    }
}
