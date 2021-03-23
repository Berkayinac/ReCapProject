using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
   public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDto> GetByDtoList();
        List<CarDto> GetByDtoList(Expression<Func<Car, bool>> filter);
    }
}
