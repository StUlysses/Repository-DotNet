using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class PoemFollow
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string PoemName { get; set; }
        [ForeignKey(nameof(Poem))]
        public Guid PoemID { get; set; }
        public Poem Poem { get; set; }
        [ForeignKey(nameof(User))]
        public Guid UserID { get; set; }
        public User User { get; set; }
    }
}
