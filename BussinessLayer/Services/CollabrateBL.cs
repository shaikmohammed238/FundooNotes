using BussinessLayer.Interfaces;
using CommonLayer.Models;
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
    }
}
