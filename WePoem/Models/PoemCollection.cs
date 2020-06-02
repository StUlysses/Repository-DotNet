using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class PoemCollection
    {
        [Key]
        public Guid PoemCollectionID { get; set; }
        [Required]
        public string PoemCollectionName { get; set; }
        public string UserName { get; set; }
        public string UserID { get; set; }
        public string PoemCount { get; set; }
    }
}
