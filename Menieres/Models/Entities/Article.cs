using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Article
    {
        [Key]
        public Guid Guid { get; set; } = Guid.NewGuid();
        /// <summary>
        /// 序号
        /// </summary>
        [Required,MaxLength(20)]
        public string Aid { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        /// <summary>
        /// 标题
        /// </summary>
        [Required,MaxLength(300, ErrorMessage = ("超过100字了"))]
        public string Title { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        [Required,MaxLength(100, ErrorMessage = ("超过50字了"))]
        public string Author { get; set; }
        /// <summary>
        /// 作者邮箱
        /// </summary>
        [MaxLength(100, ErrorMessage = ("超过100字了"))]
        public string AuthorEmail { get; set; }
        /// <summary>
        /// 附件 json
        /// </summary>
        public string? Attachment { get; set; }
        /// <summary>
        /// 配图 json
        /// </summary>
        public string? Picture { get; set; }

        /// <summary>
        /// 正文
        /// </summary>
        [Required]
        public string Content { get; set; }
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
        /// 1：文章 2：帖子(吐槽)
        /// </summary>
        public int? Type { get; set; }
        /// <summary>
        /// 审核结果
        /// -1：已删除 0：未通过(初始值) 1：已通过 2:已拒绝
        /// </summary>
        public int? Result { get; set; } = 0;
    }
}
