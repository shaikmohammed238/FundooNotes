using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ICollabrateRL
    {
       public bool AddCollabrate(CollabrateModel collabrateModel);
    }
}
