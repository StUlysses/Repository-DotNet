using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class UserFollow
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string UserName { get; set; }
        [ForeignKey(nameof(Poem))]
        public Guid PoetID { get; set; }
        public Poem Poem { get; set; }
        [ForeignKey(nameof(User))]
        public Guid UserID { get; set; }
        public User User { get; set; }
    }
}
