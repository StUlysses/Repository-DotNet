using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    /// <summary>
    /// 吐槽表
    /// </summary>
    public class Complaint
    {
        [Key]
        public Guid Guid { get; set; } = Guid.NewGuid();
        /// <summary>
        /// 外键
        /// </summary>
        [Required]
        public string Fid { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        [Required, MaxLength(100, ErrorMessage = ("超过50字了"))]
        public string Author { get; set; }
        /// <summary>
        /// 作者邮箱
        /// </summary>
        [MaxLength(100, ErrorMessage = ("超过100字了"))]
        public string AuthorEmail { get; set; }
        /// <summary>
        /// 正文
        /// </summary>
        [MaxLength(2000, ErrorMessage = ("超过300字了")), Required]
        public string Detail { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date { get; set; } = DateTime.Now;
        /// <summary>
        /// 点赞数
        /// </summary>
        public int? AgreeNum { get; set; }
        /// <summary>
        /// 鄙视数
        /// </summary>
        public int? UnagreeNum { get; set; }
        /// <summary>
        /// 类型
        /// 1:留言 2:反馈
        /// </summary>
        public int? Type { get; set; }
        /// <summary>
        /// 是否隐藏
        /// 0：隐藏 1：显示
        /// </summary>
        public int? mode { get; set; }
        /// <summary>
        /// 审核结果
        /// 0：未通过 1：通过
        /// </summary>
        public int? Result { get; set; }
    }
}
