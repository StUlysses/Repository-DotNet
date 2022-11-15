using Models;
using System.Collections.Generic;

namespace Meniere.ViewModels
{
    public class ViewModel
    {
        /// <summary>
        /// 文章模型
        /// </summary>
        public Article Article { get; set; }
        /// <summary>
        /// 文章集合
        /// </summary>
        public List<Article> ArticleList { get; set; }
        /// <summary>
        /// 文章拓展模型集合
        /// </summary>
        public List<ArticleModel> ArticleModelList { get; set; }
        /// <summary>
        /// 留言集合
        /// </summary>
        public List<Complaint> ComplaintList { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPage { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 审核模式  1 文章 2 游戏
        /// </summary>
        public int Mode { get; set; }
    }
}
