using BussinessLayer.Interfaces;
using CommonLayer.Models;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    public class LabelBL:ILabelBL
    {
        ILabelRL labelRL;
        public LabelBL(ILabelRL labelRL)
        {
            this.labelRL = labelRL;
        }
        /// <summary>
        /// create label of bussiness layer
        /// </summary>
        /// <param name="labelModel"></param>
        /// <returns></returns>
        public string CreateLabel(LabelModel labelModel)
        {
            try
            {
                return labelRL.CreateLabel(labelModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// bussiness layer of delete labei
        /// </summary>
        /// <param name="labelId"></param>
        /// <returns></returns>
        public string DeleteLabel(long labelId)
        {
            try
            {
                return labelRL.DeleteLabel(labelId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// get all label of bussiness layer
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<Label> GetAllLabels(long userId)
        {
            try
            {
                return labelRL.GetAllLabels(userId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// get label of bussiness layer
        /// </summary>
        /// <param name="labelId"></param>
        /// <returns></returns>
        public IEnumerable<Label> GetId(long labelId)
        {
            try
            {
                return labelRL.GetId(labelId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// update label of bussiness layer
        /// </summary>
        /// <param name="labelModel"></param>
        /// <param name="noteId"></param>
        /// <returns></returns>
        public string Update(LabelModel labelModel, long labelId)
        {
            try
            {
                return labelRL.Update(labelModel, labelId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
