using BussinessLayer.Interfaces;
using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
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

        //bussiness layer  ofCreateNote
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
        //bussiness layer of Delete Note
        public bool Delete(long noteId)
        {
            try
            {
                return noteRL.Delete(noteId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //bussiness layer of GetAllNote
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
        //bussiness layer of GetSinglenote
        public IEnumerable<Note> GetSingle(long NoteId)
        {
            try
            {
                return noteRL.GetSingle(NoteId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //bussiness layer of RemoveNotes
        public bool RemoveNotes(long noteId)
        {
            try
            {
                return noteRL.RemoveNotes(noteId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //bussiness layer of update notes
        public bool Update(NotesModel notesModel, long NoteId)
        {
            try
            {
                return noteRL.Update(notesModel, NoteId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //bussiness layer of archive 
        public bool Archive(long noteId)
        {
            try
            {
                return noteRL.Archive(noteId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //bussiness layer of pinned
        public bool Pinned(long noteId)
        {

            try
            {
                return noteRL.Pinned(noteId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Bussiness layer of note colour
        public string ChangeColour(string varColour, long noteId)
        {
            try
            {
                return noteRL.ChangeColour(varColour, noteId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Bussiness layer of backimg 
        public string BackImg(IFormFile url, long noteId)
        {
            try
            {
                return noteRL.BackImg(url, noteId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Bussiness layer of get show all user notes

        public IEnumerable<Note> GetEveryonesNotes()
        {
            try
            {
                return noteRL.GetEveryonesNotes();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
