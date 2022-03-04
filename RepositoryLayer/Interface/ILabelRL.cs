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
    }
}
