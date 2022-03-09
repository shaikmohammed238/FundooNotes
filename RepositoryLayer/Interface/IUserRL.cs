namespace RepositoryLayer.Interface
{
    using CommonLayer.Models;
    using RepositoryLayer.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
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
        /// <summary>
        /// interface of get all users
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers();

    }
}
