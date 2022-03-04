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
    public class CollabrateControler : ControllerBase
    {
        private readonly ICollabrateBL collabrateBL;
        private readonly FundooContext fundooContext;
        public CollabrateControler(ICollabrateBL collabrateBL, FundooContext fundooContext)
        {
            this.collabrateBL = collabrateBL;
            this.fundooContext = fundooContext;
        }

        [HttpPost("Add")]
        public IActionResult AddCollabrate(CollabrateModel collabrateModel)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = this.fundooContext.NotesTables.Where(x => x.NoteId == collabrateModel.NoteId).FirstOrDefault();
                if (result.Id == userId)
                {
                    var resultadd = this.collabrateBL.AddCollabrate(collabrateModel);
                    return this.Ok(new { status = 200, isSuccess = true, Message = "Email added to collab",Data= collabrateModel });
                }
                else
                {
                    return this.BadRequest(new { status = 400, isSuccess = false, Message = "Fail to add Email" });
                }
            }
            catch (Exception e)
            {

                return this.NotFound(new { status = 400, isSuccess = false, Message="check email and register in note" });
            }
        }
        [HttpGet("Display")]
        public IActionResult DisplayCollabrate(long noteId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = this.fundooContext.NotesTables.Where(x => x.NoteId ==noteId).FirstOrDefault();
                IEnumerable<Collabrate> collabrates = this.collabrateBL.DisplayCollabrate(noteId);
                if (collabrates != null)
                {
                    return this.Ok(new { isSuccess = true, message = "get all colabrators", data = collabrates });
                }
                else
                {
                    return this.NotFound(new { isSuccess = false, message = "check  input data " });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
