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
    public class NoteRL:INoteRL
    {
        private readonly FundooContext fundooContext;
        IConfiguration _Appsettings;
        public NoteRL(FundooContext fundooContext,IConfiguration _Appsettings)
        {
            this.fundooContext = fundooContext;
            this._Appsettings = _Appsettings;

        }

        /// <summary>
        /// method create note
        /// </summary>
        /// <param name="notesModel"></param>
        /// <returns></returns>
        /// 
        

        public Note CreateNote(NotesModel notesModel,long userId)
        {
            try
            { 
                Note newnote = new Note();
                newnote.Id = userId;
                newnote.NoteId = notesModel.NoteId;
                newnote.Tittle = notesModel.Tittle;
                newnote.Body = notesModel.Body;
                newnote.IsDeleted = notesModel.IsDeleted;
                newnote.IsArrchived = notesModel.IsArrchived;
                newnote.IsPinned = notesModel.IsPinned;
                newnote.Remainder = notesModel.Remainder;
                newnote.CreatedAt = DateTime.Now;
                newnote.Colour = notesModel.Colour;
                newnote.BackImg = notesModel.BackImg;
                //add data in database
                this.fundooContext.NotesTables.Add(newnote);
                //save data  in database
                int result = fundooContext.SaveChanges();
                if (result > 0)
                {
                    return newnote;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            { 

                throw;
            }
        }

        public bool DeleteNote(long noteId)
        {
            try
            {
                var note=this.fundooContext.NotesTables.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (note.IsDeleted == true)
                {
                    note.IsDeleted = false;
                    note.IsArrchived = false;
                    note.IsPinned = false;
                    fundooContext.SaveChanges();
                    return false;
                }
                else
                {
                    note.IsDeleted = true;
                    note.IsArrchived = false;
                    note.IsPinned = false;
                    fundooContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Note>GetAllNote(long userId)
        {
            try
            {
                return this.fundooContext.NotesTables.ToList().Where(x => x.Id == userId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
