using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Poem
    {
        [Key]
        public Guid PoemID { get; set; }
        //[Required]
        public string Title { get; set; }
        public string Auther { get; set; } 
        public Guid AutherID { get; set; }
        //[Required]
        public string Content { get; set; }
        public int WordCount { get; set; }
        public int FollowCount { get; set; }
        [ForeignKey(nameof(PoemCollection))]
        public Guid? PoemCollectionID { get; set; }
        public PoemCollection PoemCollectionName { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
