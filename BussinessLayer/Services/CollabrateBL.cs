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

        /// <summary>
        /// add colabrate of business layer
        /// </summary>
        /// <param name="collabrateModel"></param>
        /// <returns></returns>
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
        /// <summary>
        /// display all collabrate  bussiness layer
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
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
        /// <summary>
        /// bussiness layer of remove colabrate
        /// </summary>
        /// <param name="collabrateModel"></param>
        /// <returns></returns>
        public bool RemoveCollabrate(CollabrateModel collabrateModel)
        {
            try
            {
                return collabrateRL.RemoveCollabrate(collabrateModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
