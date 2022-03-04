using BussinessLayer.Interfaces;
using CommonLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public LabelController(ILabelBL labelBL, FundooContext fundooContext)
        {
            this.labelBL = labelBL;
            this.fundooContext = fundooContext;
        }
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
    }
}
