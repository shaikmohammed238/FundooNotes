using CommonLayer.Models;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class LabelRL:ILabelRL
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

        public string  CreateLabel(LabelModel labelModel)
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
    }
}
