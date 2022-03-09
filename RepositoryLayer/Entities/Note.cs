namespace RepositoryLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;
    public class Note
     {//declaring attributes
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long NoteId { get; set; }
        public string Tittle { get; set; }
        public string Body { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPinned { get; set; }
        public bool IsArrchived { get; set; }
        public DateTime? Remainder { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string Colour { get; set; }
        public string BackImg { get; set; }

        //using foreignkey use normlization
        [ForeignKey("user")]
        public long Id { get; set; }
        public virtual User user { get; set; }
     }
}
