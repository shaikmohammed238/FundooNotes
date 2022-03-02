using CommonLayer.Models;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        public User Registration(UserRegModel userRegModel);
        // public string Login(LoginUser loginUser);
        /// Interface for UserLogin
        /// </summary>
        /// <param name="userLog"></param>
        /// <returns></returns>
        public LoginResponseModel UserLogin(UserLoginModel userLog);
        //using for forget password
        public string ForgetPassword(string email);
        //using for reset password
        public bool ResetPassword(string email, string password, string confirmPassword);

    }
}
