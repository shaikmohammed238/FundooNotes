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
using System.Text;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LabelController : ControllerBase
    {
        private readonly ILabelBL labelBL;
        private readonly FundooContext fundooContext;
        private readonly IMemoryCache memoryCache;
        private readonly IDistributedCache distributCache;
        public LabelController(ILabelBL labelBL, FundooContext fundooContext, IMemoryCache memoryCache, IDistributedCache distributCache)
        {
            this.labelBL = labelBL;
            this.fundooContext = fundooContext;
            this.memoryCache = memoryCache;
            this.distributCache = distributCache;
        }

        /// <summary>
        /// api of create label 
        /// </summary>
        /// <param name="labelModel"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public IActionResult CreateLabel(LabelModel labelModel)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var labelvar = this.fundooContext.NotesTables.Where(x => x.NoteId == labelModel.NoteId).FirstOrDefault();
                if (labelvar.Id == userId)
                {
                    var result = this.labelBL.CreateLabel(labelModel);
                    return this.Ok(new { status = 200, isSuccess = true, Message = "Label Added", Data = labelModel });
                }
                else
                {
                    return this.BadRequest(new { status = 400, isSuccess = false, Message = "Fail to add Label" });
                }

            }
            catch (Exception)
            {

                return this.NotFound(new { status = 400, isSuccess = false, Message = "check email and register for create label" });
            }
            
        }
        /// <summary>
        /// api of get al api
        /// </summary>
        /// <returns></returns>

        [HttpGet("Get")]
        public IActionResult GetAllLabels()
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                IEnumerable<Label> labels = this.labelBL.GetAllLabels(userId);
                if (labels != null)
                {
                    return this.Ok(new { status = 200, isSuccess = true, Message = "showing all labels", Data = labels });
                }
                else
                {
                    return this.BadRequest(new { status = 400, isSuccess = false, Message = "create label first" });
                }
            }
            catch (Exception)
            {

                return this.NotFound(new { status = 400, isSuccess = false, Message = "check email and register for display all label" });
            }
        }
        /// <summary>
        /// api of get by id label
        /// </summary>
        /// <param name="LabelId"></param>
        /// <returns></returns>

        [HttpGet("{Id}/Get")]
        public IActionResult GetId(long LabelId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                IEnumerable<Label> labels = this.labelBL.GetId(LabelId);
                if (labels != null)
                {
                    return this.Ok(new { status = 200, isSuccess = true, Message = "showing  label", Data = labels });
                }
                else
                {
                    return this.BadRequest(new { status = 400, isSuccess = false, Message = "create label first" });
                }
            }
            catch (Exception)
            {

                return this.NotFound(new { status = 400, isSuccess = false, Message = "check email and register for display label" });
            }
        }
        /// <summary>
        /// api of get all redis
        /// </summary>
        /// <returns></returns>
        [HttpGet("Redis")]
        public async Task<IActionResult> GetAllRedisCache()
        {
            var cacheKey = "AllLabel";
            string serializedAllLabel;
            var AllLabel = new List<Label>();
            var redisAllLabel = await distributCache.GetAsync(cacheKey);
            if (redisAllLabel != null)
            {
                serializedAllLabel = Encoding.UTF8.GetString(redisAllLabel);
                AllLabel = JsonConvert.DeserializeObject<List<Label>>(serializedAllLabel);
            }
            else
            {
                AllLabel = await fundooContext.LabelTables.ToListAsync();
                serializedAllLabel = JsonConvert.SerializeObject(AllLabel);
                redisAllLabel = Encoding.UTF8.GetBytes(serializedAllLabel);
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                await distributCache.SetAsync(cacheKey, redisAllLabel, options);
            }
            return Ok(AllLabel);
        }
        /// <summary>
        /// api for label update 
        /// </summary>
        /// <param name="labelModel"></param>
        /// <param name="NoteId"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        public IActionResult Update(LabelModel labelModel,long labelId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = this.labelBL.Update(labelModel, labelId);
                return this.Ok(new { isSuccess = true, message = "updated Label", data = result });
            }
            catch (Exception)
            {
                return this.BadRequest(new { isSuccess = false, message = "label is not updated" });

            }
        }
        /// <summary>
        /// APi for delete
        /// </summary>
        /// <param name="NoteId"></param>
        /// <returns></returns>
        [HttpDelete("Delete")]
        public IActionResult DeleteLabel(long labelId)
        {
            try
            {
                long userid = Convert.ToInt32(User.Claims.FirstOrDefault(X => X.Type == "Id").Value);
                var delete = this.labelBL.DeleteLabel(labelId);
                if (delete != null)
                {
                    return this.Ok(new { isSuccess = true, message = "label delete Successfully" });
                }
                else
                {
                    return this.NotFound(new { isSuccess = false, message = " label Not delete" });
                }
            }
            catch (Exception s)
            {
                return this.BadRequest(new { Status = 401, isSuccess = false, Message = s.Message, InnerException = s.InnerException });
            }
        }
    }
}
