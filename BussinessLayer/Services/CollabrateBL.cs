using BussinessLayer.Interfaces;
using CommonLayer.Models;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    public class CollabrateBL:ICollabrateBL
    {
        ICollabrateRL collabrateRL;
        public CollabrateBL(ICollabrateRL collabrateRL)
        {
            this.collabrateRL = collabrateRL;
        }

        public bool AddCollabrate(CollabrateModel collabrateModel)
        {
            try
            {
                return collabrateRL.AddCollabrate(collabrateModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Collabrate> DisplayCollabrate(long noteId)
        {
            try
            {
                return collabrateRL.DisplayCollabrate(noteId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
