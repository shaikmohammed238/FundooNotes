// <auto-generated />
//------------------------------------------------------
// <copyright file="Collabratemodel.cs" company="Bridgelabz">
// shaik mohammed ghouse
// </copyright>
//------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Models
{
    public class CollabrateModel
    {
        [Required]
        public long NoteId { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
