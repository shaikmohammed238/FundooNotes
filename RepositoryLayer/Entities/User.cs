namespace RepositoryLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    public class User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        [RegularExpression("^[A-Z][A-Z a-z]{2,}$")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression("^[A-Z][A-Z a-z]{2,}$")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z a-z]{2,}[@][a-z A-z]{2,6}[.][com]$")]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^[A-Z][A-Z a-z 1-0]{2,}$")]
        public String Password { get; set; }
        public DateTime? CreatedAt { get; set; }  
        public DateTime? ModifiedAt { get; set; }
        public ICollection<Note> Notes { get; set; }

    }
}
