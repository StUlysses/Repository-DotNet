using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class PLog
    {
        [Key]
        public Guid LogID { get; set; } = Guid.NewGuid();
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public string URL { get; set; }
        public string IP { get; set; }
        public string SQL { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
