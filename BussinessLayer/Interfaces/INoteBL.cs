using CommonLayer.Models;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interfaces
{
    public interface INoteBL
    {
        //interface of bussniess layer create note
        public Note CreateNote(NotesModel notesModel, long userId);
        //interface of bussniess layer GetAllNote
        public IEnumerable<Note> GetAllNote(long userId);
        //interface of bussniess layer GetSingle note
        public IEnumerable<Note> GetSingle(long NoteId);
        //interface of bussniess layer Update note
        public bool Update(NotesModel notesModel, long NoteId);
        //interface of bussniess layer RemoveNotes
        public bool RemoveNotes(long noteId);
        //interface of bussniess layer Deletenote
        public bool Delete(long noteId);
        //interface of bussniess layer Archivenote
        public bool Archive(long noteId);
        //interface of bussniess layer Pinned Note
        public bool Pinned(long noteId);
    }
}
