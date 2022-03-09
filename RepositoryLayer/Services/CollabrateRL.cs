

namespace RepositoryLayer.Services
{
    using CommonLayer.Models;
    using Microsoft.Extensions.Configuration;
    using RepositoryLayer.Context;
    using RepositoryLayer.Entities;
    using RepositoryLayer.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class CollabrateRL:ICollabrateRL
    {
        private readonly FundooContext fundooContext;
        
        public CollabrateRL(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
            

        }
        /// <summary>
        /// mthod for add colobrate
        /// </summary>
        /// <param name="collabrateModel"></param>
        /// <returns></returns>

        public bool AddCollabrate(CollabrateModel collabrateModel)
        {
            try
            {
                var notedata = this.fundooContext.NotesTables.Where(s => s.NoteId == collabrateModel.NoteId).FirstOrDefault();
                var userdata = this.fundooContext.UserTables.Where(s => s.Email == collabrateModel.Email).FirstOrDefault();
                if (notedata != null && userdata != null)
                {
                    Collabrate collabrateobj = new Collabrate();
                    collabrateobj.Id = userdata.Id;
                    collabrateobj.NoteId = collabrateModel.NoteId;
                    collabrateobj.CollabeEmail = collabrateModel.Email;
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

        /// <summary>
        /// method for display  all collabrate
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
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
        /// <summary>
        /// method of Remove collab
        /// </summary>
        /// <param name="collabrateModel"></param>
        /// <returns></returns>
        public bool RemoveCollabrate(CollabrateModel collabrateModel)
        {
            try
            {
                var collabvar = this.fundooContext.CollabratesTables.Where(x => x.CollabeEmail == collabrateModel.Email).FirstOrDefault();
                if (collabvar != null)
                {
                    this.fundooContext.CollabratesTables.Remove(collabvar);
                    this.fundooContext.SaveChangesAsync();
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
    }
}
