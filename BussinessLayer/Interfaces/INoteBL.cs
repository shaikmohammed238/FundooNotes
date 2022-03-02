using CommonLayer.Models;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interfaces
{
    public interface INoteBL
    {
        public Note CreateNote(NotesModel notesModel, long userId);
        public IEnumerable<Note> GetAllNote(long userId);
        public bool DeleteNote(long noteId);
    }
}
