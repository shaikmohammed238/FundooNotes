using BussinessLayer.Interfaces;
using CommonLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using RepositoryLayer.Context;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL;
        private readonly IMemoryCache memoryCache;
        private readonly IDistributedCache distributCache;
        private readonly FundooContext fundooContext;
        public UserController(IUserBL userBL, IMemoryCache memoryCache, IDistributedCache distributCache, FundooContext fundooContext)
        {
            this.userBL = userBL;
            this.memoryCache = memoryCache;
            this.distributCache = distributCache;
            this.fundooContext = fundooContext;
        }
        [HttpPost("Register")]
        public IActionResult addUser(UserRegModel userRegModel)
        {
            try
            {
                var result = userBL.Registration(userRegModel);
                if (result != null)
                {
                    return this.Ok(new { isSuccess = true, message = "Registration Successful", data = result });
                }
                else
                    return this.BadRequest(new { isSuccess = false, message = "Registration Unsuccessful" });
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Get all Login Data
        /// </summary>
        /// <param name="userLog"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public IActionResult UserLogin(UserLoginModel userLog)
        {
            try
            {
                var result = userBL.UserLogin(userLog);
                if (result != null)
                {
                    return this.Ok(new { isSuccess = true, message = "Login Successful", data = result.Token });
                }
                else
                    return this.BadRequest(new { isSuccess = false, message = "Login Unsuccessful" });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("ForgotPassword")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                var result = userBL.ForgetPassword(email);
                if (result != null)
                {
                    return this.Ok(new { isSuccess = true, message = "Send Forget Password Link" });
                }
                else
                    return this.BadRequest(new { isSuccess = false, message = "Email not Found" });
            }
            catch (Exception e)
            {

                return this.BadRequest(new { isSuccess = false, message = e.InnerException.Message });
            }
        }


        [Authorize]
        [HttpPost("ResetPassword")]

        public IActionResult ResetPassword(string password, string confirmPassword)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var result = userBL.ResetPassword(email, password, confirmPassword);
                return this.Ok(new { isSuccess = true, message = "Reset Password Successfully" });

            }
            catch (Exception e)
            {

                return this.BadRequest(new { isSuccess = false, message = e.InnerException.Message });
            }
        }
        /// <summary>
        /// api of cache memory
        /// </summary>
        /// <returns></returns>

        [HttpGet("Redis")]

        public async Task<IActionResult> GetAllRedisCache()
        {
            var cacheKey = "AllUsers";
            string serializedAllUsers;
            var AllUsers = new List<User>();
            var redisAllUsers = await distributCache.GetAsync(cacheKey);
            if (redisAllUsers != null)
            {
                serializedAllUsers = Encoding.UTF8.GetString(redisAllUsers);
                AllUsers = JsonConvert.DeserializeObject<List<User>>(serializedAllUsers);
            }
            else
            {
                AllUsers = await fundooContext.UserTables.ToListAsync();
                serializedAllUsers = JsonConvert.SerializeObject(AllUsers);
                redisAllUsers = Encoding.UTF8.GetBytes(serializedAllUsers);
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                await distributCache.SetAsync(cacheKey, redisAllUsers, options);
            }
            return Ok(AllUsers);
        }
    }
}