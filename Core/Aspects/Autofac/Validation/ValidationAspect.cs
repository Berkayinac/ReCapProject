using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.CrossCuttingConcerns.Validation;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect :MethodInterception
    {
        Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            var checkValidatior = typeof(IValidator).IsAssignableFrom(validatorType);
            if (!checkValidatior)
            {
                throw new ValidationException("Bu bir doğrulama sınıfı değil");
            }
            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(x => x.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }

        }
    }
}
