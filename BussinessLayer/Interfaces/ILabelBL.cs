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
        public string CreateLabel(LabelModel labelModel);
    }
}
