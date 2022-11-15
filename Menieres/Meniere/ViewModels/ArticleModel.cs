using Models;
using System;
using System.Collections.Generic;

namespace Meniere.ViewModels
{
    public class ArticleModel
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
        /// <summary>
        /// 序号
        /// </summary>
        public string Aid { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 作者邮箱
        /// </summary>
        public string AuthorEmail { get; set; }
        /// <summary>
        /// 正文
        /// </summary>
        public string Content { get; set; }
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
        /// 1：文章 2：帖子(吐槽) 3:游戏 4：小说
        /// </summary>
        public int? Type { get; set; }
        /// <summary>
        /// 评论集合
        /// </summary>
        public List<Complaint> ComplaintList { get; set; }
    }
}
