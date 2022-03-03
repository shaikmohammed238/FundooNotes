using CommonLayer.Models;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface INoteRL
    {
        // noterl interface create note
        public Note CreateNote(NotesModel notesModel, long userId);
        //get all notes
        public IEnumerable<Note> GetAllNote(long userId);
        public bool DeleteNote(long noteId);
        public bool UpdateNote(Note note, long userId);
    }
}
