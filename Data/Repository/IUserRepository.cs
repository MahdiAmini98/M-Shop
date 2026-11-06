using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M_Shop.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace M_Shop.Data.Repository
{ 
  public  interface IUserRepository
  {

      void AddUser(Users users);
      //بررسی میکند ایمیل تکراری ثبت نام نشود

        bool IsExistEmail(string Email);

        //برگرداند یک کاربر از دیتا بیس برای ورود کاربر به سایت و لاگین شدن کاربر

        Users GetUserForLogin(string email,string password);

  }



  ///////Class Repository
  
    public class UserRepository:IUserRepository
    {
        private MShop_DBContext _context;

        public UserRepository(MShop_DBContext context)
        {
            _context = context;
        }
        public void AddUser(Users users)
        {
            _context.Users.Add(users);
            _context.SaveChanges();

        }

        public bool IsExistEmail(string Email)
        {
            return _context.Users.Any(a => a.Email == Email);


        }

        public Users GetUserForLogin(string email, string password)
        {
            return _context.Users.FirstOrDefault(c => c.Email == email && c.Password == password);
        }
    }

}
