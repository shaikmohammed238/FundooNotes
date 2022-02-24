using BussinessLayer.Interfaces;
using CommonLayer.Models;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public User Registration(UserRegModel userRegModel)
        {
            try
            {
                return userRL.Registration(userRegModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // string IUserBL.Login(LoginUser loginUser)
        //{
        //    try
        //    {
        //        return userRL.Login(loginUser);

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public LoginResponseModel UserLogin(UserLoginModel userLog)
        {
            try
            {
                return this.userRL.UserLogin(userLog);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
