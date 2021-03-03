using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {

            var classAttibutes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true)
                .ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttibutes.AddRange(methodAttributes);

            return classAttibutes.OrderBy(x => x.Priority).ToArray();

        }
    }
}
