using CommonLayer.Models;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interfaces
{
    public interface IUserBL
    {
        public User Registration(UserRegModel userRegModel);
        //  public string Login(LoginUser loginUser);
        public LoginResponseModel UserLogin(UserLoginModel userLog);
    }
}
