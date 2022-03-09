namespace RepositoryLayer.Interface
{
    using CommonLayer.Models;
    using Microsoft.AspNetCore.Http;
    using RepositoryLayer.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface INoteRL
    {
        // noterl interface create note
        public Note CreateNote(NotesModel notesModel, long userId);
        //get all notes
        public IEnumerable<Note> GetAllNote(long userId);
        /// <summary>
        /// getsingle note id
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        public IEnumerable<Note> GetSingle(long noteId);

        /// <summary>
        /// interface of delete reposirory layer
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        public bool Delete(long noteId);

        /// <summary>
        /// interface of update reposirory layer
        /// </summary>
        /// <param name="notesModel"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool Update(NotesModel notesModel, long NoteId);

        /// <summary>
        /// interface of Remove notes reposirory layer
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        public bool RemoveNotes(long noteId);
        /// <summary>
        /// interface of Archive notes reposirory layer
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        public bool Archive(long noteId);

        /// <summary>
        /// interface of pinned notes reposirory layer
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        public bool Pinned(long noteId);
        /// <summary>
        /// interface of notescolour reposirory layer
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        public string ChangeColour(string varColour, long noteId);
        /// <summary>
        /// interface of backimg reposirory layer
        /// </summary>
        /// <param name="bimgurl"></param>
        /// <param name="noteId"></param>
        /// <returns></returns>
        public string BackImg(IFormFile url, long noteId);
        /// <summary>
        /// interface of Get all user notes reposirory layer
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Note> GetEveryonesNotes();
    }
}
