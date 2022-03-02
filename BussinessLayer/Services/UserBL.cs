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
        //forget password required email
        public string ForgetPassword(string email)
        {
            try
            {
                return userRL.ForgetPassword(email);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //reset pasword required email, password,confirmpassword
        public bool ResetPassword(string email, string password, string confirmPassword)
        {
            try
            {
                return this.userRL.ResetPassword(email, password, confirmPassword);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
