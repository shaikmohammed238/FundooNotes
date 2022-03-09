namespace FundooNotes.Controllers
{
    using BussinessLayer.Interfaces;
    using CommonLayer.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
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


    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NoteController : ControllerBase
    {
        private readonly INoteBL noteBL;
        private readonly FundooContext fundooContext;
        private readonly IMemoryCache memoryCache;
        private readonly IDistributedCache distributCache;
        public NoteController(INoteBL noteBL, FundooContext fundooContext, IMemoryCache memoryCache, IDistributedCache distributCache)
        {
            this.noteBL = noteBL;
            this.fundooContext = fundooContext;
            this.memoryCache = memoryCache;
            this.distributCache = distributCache;
        }
        /// <summary>
        /// crete note api
        /// </summary>
        /// <param name="notesModel"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public IActionResult CreateNote(NotesModel notesModel)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = noteBL.CreateNote(notesModel, userId);
                if (result != null)
                {
                    return this.Ok(new { isSuccess = true, message = "created successfull", data = result });
                }
                else
                    return this.BadRequest(new { isSuccess = false, message = "not created" });
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// get all user note api
        /// </summary>
        /// <returns></returns>
        [HttpGet("ShowAll")]
        public IActionResult ShowEveryoneNotes()
        {
            try
            {
                IEnumerable<Note> note = this.noteBL.GetEveryonesNotes();
                if (note != null)
                {
                    return this.Ok(new { status = 200, isSuccess = true, message = "Successful", data = note });
                }
                else
                {
                    return this.NotFound(new { status = 404, isSuccess = false, message = "No Notes Found" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = 401, isSuccess = false, Message = e.InnerException.Message });
            }
        }


        /// <summary>
        /// get all note api
        /// </summary>
        /// <returns></returns>

        [HttpGet("Get")]
        public IActionResult GetAllNote()
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                IEnumerable<Note> note = this.noteBL.GetAllNote(userId);
                if (note != null)
                {
                    return this.Ok(new { isSuccess = true, message = "get all notes", data = note });
                }
                else
                {
                    return this.NotFound(new { isSuccess = false, message = "not get" });
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// single note api
        /// </summary>
        /// <param name="NoteId"></param>
        /// <returns></returns>

        [HttpGet("{Id}/Get")]
        public IActionResult GetSingle(int NoteId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                IEnumerable<Note> notesin = this.noteBL.GetSingle(NoteId);
                return this.Ok(new { isSuccess = true, message = "Data of the Single NoteId", data = notesin });
            }
            catch (Exception)
            {
                return this.BadRequest(new { isSuccess = false, message = "check NoteId" });
            }
        }
        /// <summary>
        /// APi of redis get 
        /// </summary>
        /// <returns></returns>
        [HttpGet("redis")]
        public async Task<IActionResult> GetAllNotesUsingRedisCache()
        {
            var cacheKey = "NotesList";
            string serializedNotesList;
            var notesList = new List<Note>();
            var redisNotesList = await this.distributCache.GetAsync(cacheKey);
            if (redisNotesList != null)
            {
                serializedNotesList = Encoding.UTF8.GetString(redisNotesList);
                notesList = JsonConvert.DeserializeObject<List<Note>>(serializedNotesList);
            }
            else
            {
                notesList = (List<Note>)this.noteBL.GetEveryonesNotes();
                serializedNotesList = JsonConvert.SerializeObject(notesList);
                redisNotesList = Encoding.UTF8.GetBytes(serializedNotesList);
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                await this.distributCache.SetAsync( cacheKey, redisNotesList, options);
            }
            return this.Ok(notesList);
        }
        /// <summary>
        /// update api
        /// </summary>
        /// <param name="notesModel"></param>
        /// <param name="NoteId"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        public IActionResult Update(NotesModel notesModel, long NoteId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = this.noteBL.Update(notesModel, NoteId);
                return this.Ok(new { isSuccess = true, message = "updated notes", data = result });
            }
            catch (Exception)
            {
                return this.BadRequest(new { isSuccess = false, message = "note is not updated" });

            }
        }
        /// <summary>
        /// remove nnote api 
        /// </summary>
        /// <param name="NoteId"></param>
        /// <returns></returns>
        [HttpDelete("Remove")]
        public IActionResult RemoveNotes(long NoteId)
        {
            try
            {
                long userid = Convert.ToInt32(User.Claims.FirstOrDefault(X => X.Type == "Id").Value);
                var remove = this.noteBL.RemoveNotes(NoteId);
                if (remove != true)
                {
                    return this.Ok(new { isSuccess = true, message = "Notes Removed Successfully" });
                }
                else
                {
                    return this.NotFound(new { isSuccess = false, message = " Notes Not Removed" });
                }
            }
            catch (Exception s)
            {
                return this.BadRequest(new { Status = 401, isSuccess = false, Message = s.Message, InnerException = s.InnerException });
            }
        }
        /// <summary>
        /// delete note api
        /// </summary>
        /// <param name="NoteId"></param>
        /// <returns></returns>
        [HttpPut("Delete")]
        public IActionResult Delete(long NoteId)
        {
            try
            {
                long userid = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = this.noteBL.Delete(NoteId);
                if (result == true)
                {
                    return this.Ok(new { status = 200, isSuccess = true, Message = "Note has Been Permentely Deleted!", data = result });
                }
                if (result == false)
                {
                    return this.Ok(new { status = 200, isSuccess = true, Message = "Note has been Recovered" });
                }
                return this.BadRequest(new { status = 400, isSuccess = false, Message = "Error" });
            }
            catch (Exception s)
            {
                return this.BadRequest(new { Status = false, Message = s.Message, InnerException = s.InnerException });
            }
        }
        /// <summary>
        /// archive note api
        /// </summary>
        /// <param name="NoteId"></param>
        /// <returns></returns>
        [HttpPatch("Archive")]
        public IActionResult Archive(long NoteId)
        {
            try
            {
                long userid = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var Archiveresult = this.noteBL.Archive(NoteId);
                if (Archiveresult == true)
                {
                    return this.Ok(new { status = 200, isSuccess = true, Message = "Note has been Archived", data = Archiveresult });
                }
                if (Archiveresult == false)
                {
                    return this.Ok(new { status = 200, isSuccess = true, Message = "Note has been Un-Archived" });
                }
                return this.BadRequest(new { status = 400, isSuccess = false, Message = "Error" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message, InnerException = e.InnerException });
            }
        }
        /// <summary>
        /// pinned Api
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        [HttpPatch("Pinned")]
        public IActionResult Pinned(long noteId)
        {
            try
            {
                long userid = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = this.noteBL.Pinned(noteId);
                if (result == true)
                {
                    return this.Ok(new { status = 200, isSuccess = true, Message = "Note has been Pinned!", data = result });
                }
                if (result == false)
                {
                    return this.Ok(new { status = 200, isSuccess = true, Message = "Note has been Un-Pinned" });
                }
                return this.BadRequest(new { status = 400, isSuccess = false, Message = "check again note id" });
            }
            catch (Exception s)
            {
                return this.BadRequest(new { Status = false, Message = s.Message, InnerException = s.InnerException });
            }
        }
        /// <summary>
        /// api for change colour
        /// </summary>
        /// <param name="varColour"></param>
        /// <param name="noteId"></param>
        /// <returns></returns>
        [HttpPatch("ChangeColour")]
        public IActionResult ChangeColour( string varColour, long noteId)
        {
            try
            {
                long userid = Convert.ToInt32(User.Claims.FirstOrDefault(X => X.Type == "Id").Value);
                var result = this.noteBL.ChangeColour(varColour, noteId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "colour Updated Successful", data = result });
                }
                else
                {
                    return this.NotFound(new { isSuccess = false, message = "not changedd colour" });
                }
            }
            catch (Exception s)
            {
                return this.BadRequest(new { Status = false, Message = s.Message, InnerException = s.InnerException });
            }

        }
        /// <summary>
        /// background image api
        /// </summary>
        /// <param name="url"></param>
        /// <param name="noteId"></param>
        /// <returns></returns>
        [HttpPatch("Image")]
        public IActionResult BackImg(IFormFile url, long noteId)
        {
            try
            {
                
                    long userid = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                    var result = this.noteBL.BackImg(url, noteId);
                    if (result != null)
                    {
                        return this.Ok(new { success = true, message = " Image Successful", data = result });
                    }
                    else
                    {
                        return this.NotFound(new { isSuccess = false, message = " not added img" });
                    }
                
            }
            catch (Exception s)
            {
                return this.BadRequest(new { Status = false, Message = s.Message, InnerException = s.InnerException });
            }
        }
    }        
}       
