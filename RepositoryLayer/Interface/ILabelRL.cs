using CommonLayer.Models;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ILabelRL
    {
        //interface of the repository layer for create label
        public string CreateLabel(LabelModel labelModel);
        //interface of the repository layer for get all label
        public IEnumerable<Label> GetAllLabels(long userId);
        //interface of the repository layer for get id label
        public IEnumerable<Label> GetId(long labelId);
        //interface of the repository layer for update label
        public string Update(LabelModel labelModel, long labelId);
        //interface of the repository layer for delete label
        public string DeleteLabel(long labelId);
    }
}
