

namespace RepositoryLayer.Services
{
    using CommonLayer.Models;
    using Microsoft.Extensions.Configuration;
    using RepositoryLayer.Context;
    using RepositoryLayer.Entities;
    using RepositoryLayer.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class LabelRL : ILabelRL
    {
        private readonly FundooContext fundooContext;
        IConfiguration _Appsettings;
        IConfiguration config;
        public LabelRL(FundooContext fundooContext, IConfiguration _Appsettings, IConfiguration config)
        {
            this.fundooContext = fundooContext;
            this._Appsettings = _Appsettings;
            this.config = config;

        }

        /// <summary>
        /// method of create label
        /// </summary>
        /// <param name="labelModel"></param>
        /// <returns></returns>
        public string CreateLabel(LabelModel labelModel)
        {
            try
            {
                var note = this.fundooContext.NotesTables.Where(x => x.NoteId == labelModel.NoteId).FirstOrDefault();


                Label labelobj = new Label();
                labelobj.LabelName = labelModel.LabelName;
                labelobj.NoteId = note.NoteId;
                labelobj.Id = note.Id;
                this.fundooContext.LabelTables.Add(labelobj);
                int result = fundooContext.SaveChanges();
                if (result > 0)
                {
                    return "labelobj";
                }
                else
                {
                    return "null";
                }


            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// method of delete label
        /// </summary>
        /// <param name="labelId"></param>
        /// <returns></returns>

        public string DeleteLabel(long labelId)
        {
            try
            {
                var Deletelabel = this.fundooContext.LabelTables.Where(x => x.LabelId == labelId).FirstOrDefault();

                if (Deletelabel!= null)
                {

                    this.fundooContext.LabelTables.Remove(Deletelabel);
                    this.fundooContext.SaveChanges();
                    return "Label Deleted Successfully";
                }
                else
                {
                    return "Label not delete";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Method of get all labels
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<Label> GetAllLabels(long userId)
        {
            try
            {
                return this.fundooContext.LabelTables.ToList().Where(x => x.Id == userId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// method of get by id
        /// </summary>
        /// <param name="labelId"></param>
        /// <returns></returns>
        public IEnumerable<Label> GetId(long labelId)
        {
            try
            {
                return this.fundooContext.LabelTables.ToList().Where(x => x.LabelId == labelId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// method of update label
        /// </summary>
        /// <param name="labelModel"></param>
        /// <param name="labelId"></param>
        /// <returns></returns>
        public string Update(LabelModel labelModel, long labelId)
        {
            try
            {
                var result = this.fundooContext.LabelTables.Where(x => x.LabelId == labelId).FirstOrDefault();
                if (result != null)
                {
                    result.NoteId = labelModel.NoteId;
                    result.LabelName = labelModel.LabelName;
                    this.fundooContext.SaveChanges();
                    return "Label is successfully changed ";

                }
                else
                {
                    return "check label is created or not";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }   
}
