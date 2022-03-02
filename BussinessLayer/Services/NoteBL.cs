using BussinessLayer.Interfaces;
using CommonLayer.Models;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    public class NoteBL : INoteBL
    {
        INoteRL noteRL;
        public NoteBL(INoteRL noteRL)
        {
            this.noteRL = noteRL;
        }

        public Note CreateNote(NotesModel notesModel, long userId)
        {
            try
            {
                return noteRL.CreateNote(notesModel,userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteNote( long noteId)
        {
            try
            {
                return noteRL.DeleteNote(noteId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Note> GetAllNote(long userId)
        {
            try
            {
                return noteRL.GetAllNote(userId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
