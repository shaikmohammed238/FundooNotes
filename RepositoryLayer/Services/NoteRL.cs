using CommonLayer.Models;
using Microsoft.EntityFrameworkCore;
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

       

        /// <summary>
        /// method for get all note
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>


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

        /// <summary>
        /// get single note
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        public IEnumerable<Note> GetSingle(long noteId)
        {

            try
            {
                return this.fundooContext.NotesTables.ToList().Where(x => x.Id == noteId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        

        /// <summary>
        /// method of update note
        /// </summary>
        /// <param name="notesModel"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool Update(NotesModel notesModel,long NoteId)
        {
            try
            {
                var updateresult = this.fundooContext.NotesTables.Where(x => x.NoteId == notesModel.NoteId).FirstOrDefault();
                if (updateresult!=null)
                {
                    updateresult.Tittle = notesModel.Tittle;
                    updateresult.Body = notesModel.Body;
                    updateresult.ModifiedAt = DateTime.Now;
                    updateresult.BackImg= notesModel.BackImg;
                    updateresult.Colour = notesModel.Colour;
                    this.fundooContext.SaveChanges();
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
        /// method of remove notes
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        public bool RemoveNotes(long noteId)
        {
            try
            {
                var removeNote = this.fundooContext.NotesTables.Where(x => x.NoteId == noteId).FirstOrDefault();
                this.fundooContext.NotesTables.Remove(removeNote);
                this.fundooContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// method of delete note
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        public bool Delete(long noteId)
        {
            try
            {
                var DeleteNote = this.fundooContext.NotesTables.Where(x => x.NoteId == noteId).FirstOrDefault();

                if (DeleteNote.IsDeleted == false)
                {
                    DeleteNote.IsDeleted = true;
                    this.fundooContext.SaveChanges();
                    return true;
                }
                else
                {
                    DeleteNote.IsDeleted = false;
                    DeleteNote.ModifiedAt = DateTime.Now;
                    this.fundooContext.NotesTables.Update(DeleteNote);
                    fundooContext.SaveChanges();
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// method of archive
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        public bool Archive(long noteId)
        {
            try
            {
                var Archivemodel = this.fundooContext.NotesTables.Where(x => x.NoteId == noteId).FirstOrDefault();

                if (Archivemodel.IsArrchived == false)
                {
                    Archivemodel.IsArrchived = true;
                    this.fundooContext.SaveChanges();
                    return true;
                }
                else
                {
                    Archivemodel.IsArrchived = false;
                    Archivemodel.ModifiedAt = DateTime.Now;
                    this.fundooContext.NotesTables.Update(Archivemodel);
                    this.fundooContext.SaveChanges();
                    return false;
                }
            }
            catch (Exception)
            {
                {
                    throw;
                }
            }
        }
        /// <summary>
        /// Method of pinned note
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        public bool Pinned(long noteId)
        {
            try
            {
                var PinnedNote = this.fundooContext.NotesTables.Where(x => x.NoteId == noteId).FirstOrDefault();

                if (PinnedNote.IsPinned == false)
                {
                    PinnedNote.IsPinned = true;
                    this.fundooContext.SaveChanges();
                    return true;
                }
                else
                {
                    PinnedNote.IsPinned = false;
                    PinnedNote.ModifiedAt = DateTime.Now;
                    this.fundooContext.NotesTables.Update(PinnedNote);
                    this.fundooContext.SaveChanges();
                    return false;
                }
            }
            catch (Exception)
            {
                {
                    throw;
                }
            }
        }
    }
}
