using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entities
{
    public class Collabrate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CollabeId { get; set; }
        public string CollabeEmail { get; set; }
        [ForeignKey("user")]
        public long Id { get; set; }
        public User user { get; set; }
        
        [ForeignKey("note")]
        public long NoteId { get; set; }
        public Note note { get; set; }
        
    }
}
