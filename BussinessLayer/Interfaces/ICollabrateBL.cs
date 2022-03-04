using CommonLayer.Models;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interfaces
{
    public interface ICollabrateBL
    {
        //interface of bussiness layer add colabrate
        public bool AddCollabrate(CollabrateModel collabrateModel);
        //interface of business layer display all collabrate
        public IEnumerable<Collabrate> DisplayCollabrate(long noteId);
        //interface of business layer remove collabrate
        public bool RemoveCollabrate(CollabrateModel collabrateModel);
    }
}
