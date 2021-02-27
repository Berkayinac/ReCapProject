using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CarRentalContext>, IUserDal
    {
        public List<UserDto> GetUsersByDto()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from u in context.Users
                             join c in context.Customers
                             on u.UserId equals c.UserId
                             select new UserDto { UserId = u.UserId, FirstName = u.FirstName, LastName = u.LastName, Email = u.Email, CompanyName = c.CompanyName, Password = u.Password };

                return result.ToList();      
            }
        }
    }
}

//Expression<Func<User, bool>> filter