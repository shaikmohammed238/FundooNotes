using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace BussinessLayer.Interfaces
{
    public interface ILabelBL
    {
        //interface of bussiness layer for create label
        public string CreateLabel(LabelModel labelModel);
        //interface of bussiness laayer for get all labels
        public IEnumerable<Label> GetAllLabels(long userId);
        //interface of bussiness laayer for get Id labels
        public IEnumerable<Label> GetId(long labelId);
        //interface of bussiness laayer for update labels
        public string Update(LabelModel labelModel, long labelId);
        //interface of bussiness laayer for delete labels
        public string DeleteLabel(long labelId);
    }
}
