using CommonLayer.Models;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ICollabrateRL
    {
        //interface of repository layer add colabrate
       public bool AddCollabrate(CollabrateModel collabrateModel);
        //interface of repository Display all colabrate
        public IEnumerable<Collabrate> DisplayCollabrate(long noteId);
        //interface of repository remove colabrate
        public bool RemoveCollabrate(CollabrateModel collabrateModel);
    }
}
