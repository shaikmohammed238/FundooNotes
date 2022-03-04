using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Models
{
    public class LabelModel
    {
        [Required]
        public long NoteId { get; set; }
        [Required]
        public string LabelName { get; set; }
    }
}
