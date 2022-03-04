using CommonLayer.Models;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class CollabrateRL:ICollabrateRL
    {
        private readonly FundooContext fundooContext;
        
        public CollabrateRL(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
            

        }

        public bool AddCollabrate(CollabrateModel collabrateModel)
        {
            try
            {
                var notedata = this.fundooContext.NotesTables.Where(s => s.NoteId == collabrateModel.NoteId).FirstOrDefault();
                var userdata = this.fundooContext.UserTables.Where(s => s.Email == collabrateModel.CollabeEmail).FirstOrDefault();
                if (notedata != null && userdata != null)
                {
                    Collabrate collabrateobj = new Collabrate();
                    collabrateobj.Id = userdata.Id;
                    collabrateobj.NoteId = collabrateModel.NoteId;
                    collabrateobj.CollabeEmail = collabrateModel.CollabeEmail;
                    this.fundooContext.CollabratesTables.Add(collabrateobj);
                }
                int result = this.fundooContext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Collabrate> DisplayCollabrate(long noteId)
        {
            try
            {
                return this.fundooContext.CollabratesTables.ToList().Where(x => x.NoteId == noteId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
