using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    /// <summary>
    /// 审核表
    /// </summary>
    public class Review
    {
        [Key]
        public Guid Guid { get; set; } = Guid.NewGuid();
        /// <summary>
        /// 序号
        /// </summary>
        [Required]
        public string Fid { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Required, MaxLength(100, ErrorMessage = ("超过100字了"))]
        public string Title { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(2000,ErrorMessage =("超过300字了"))]
        public string Description { get; set; }
        /// <summary>
        /// 审核结果
        /// </summary>
        public bool Result { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
