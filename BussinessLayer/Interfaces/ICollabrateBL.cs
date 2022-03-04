using CommonLayer.Models;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interfaces
{
    public interface ICollabrateBL
    {
        public bool AddCollabrate(CollabrateModel collabrateModel);
        public IEnumerable<Collabrate> DisplayCollabrate(long noteId);
    }
}
