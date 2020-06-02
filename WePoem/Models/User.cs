using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        [Key]
        public Guid UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        /// <summary>
        /// true:男,false:女
        /// </summary>
        public bool Gender { get; set; }
        /// <summary>
        /// white:白昼,black:黑夜,green:豆沙绿
        /// </summary>
        public string BgColor { get; set; }
    }
}
