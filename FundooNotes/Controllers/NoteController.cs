using BussinessLayer.Interfaces;
using CommonLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Context;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NoteController : ControllerBase
    {
        private readonly INoteBL noteBL;
        private readonly FundooContext fundooContext;
        public NoteController(INoteBL noteBL, FundooContext fundooContext)
        {
            this.noteBL = noteBL;
            this.fundooContext = fundooContext;
        }
        [HttpPost("CreateNote")]
        public IActionResult CreateNote (NotesModel notesModel)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = noteBL.CreateNote(notesModel,userId);
                if (result != null)
                {
                    return this.Ok(new { isSuccess = true, message = "created successfull" ,data=result });
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
        /// create for get api 
        /// </summary>
       
        [HttpPost("Get All Note")]
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

                throw ;
            }
            
        }
        [HttpDelete("deleteNote")]
        public IActionResult DeleteNote(long noteId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var noteDelete = this.fundooContext.NotesTables.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (noteDelete.Id == userId)
                {
                    var result = this.noteBL.DeleteNote(noteId);
                    if (result == true)
                    {
                       return this.Ok(new { isSuccess = true, message = "note  in trash"});
                    }
                    else
                    {
                        return this.Ok(new { isSuccess =false, message = "note is untrash" });
                    }
                }
                else
                {
                    return this.Unauthorized(new { isSuccess = false, message = "unauthorized user" });
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpPatch("UpdateNote")]
        public IActionResult UpdateNote(Note note)
        {
            try
            {
                long userId = Convert.ToInt64(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = this.noteBL.UpdateNote(note,userId);
                return this.Ok(new { isSuccess = true, message = "note is updated" });
                
            }
            catch (Exception)
            {

                return this.BadRequest(new { isSuccess = false, message = "note failed to update" });
            }
        }
       // [HttpPatch("U")]
    }
}
