using Models;
using Models.MongoDB.Model;

namespace Services
{
    /// <summary>
    /// 文字类接口
    /// </summary>
    public interface IWordService
    {
        #region 文章模块
        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <param name="type">1：文章 2：帖子(吐槽) 3:游戏 4：小说</param>
        /// <param name="result">-1：已删除 0：未通过(初始值) 1：已通过 2:已拒绝</param>
        /// <returns></returns>
        int FindTotalPage(int type, int result = 1);
        /// <summary>
        /// 查找文章集合
        /// 根据时间降序
        /// </summary>
        /// <param name="currentPage">当前页码</param>
        /// <param name="type">1：文章 2：帖子(吐槽)</param>
        /// <param name="result">-1：已删除 0：未通过(初始值) 1：已通过 2:已拒绝</param>
        /// <returns></returns>
        List<Article> FindArticlesOrderByDate(int currentPage,int type, int result = 1);
        /// <summary>
        /// 根据id查找文章
        /// </summary>
        /// <param name="guid">主键</param>
        /// <returns></returns>
        Article FindArticleByGuid(Guid guid);
        /// <summary>
        /// 保存文章
        /// </summary>
        /// <param name="article">文章实体</param>
        void SaveArticle(Article article);
        /// <summary>
        /// 根据id更新文章
        /// </summary>
        /// <param name="article"></param>
        Task UpdateArticle(Article article);

        #endregion

        #region 吐槽模块
        /// <summary>
        /// 保存留言
        /// </summary>
        /// <param name="complaint">评论实体</param>
        void SaveComplaint(Complaint complaint);
        /// <summary>
        /// 查询留言
        /// </summary>
        /// <param name="guid">外键</param>
        /// <returns></returns>
        List<Complaint> FindComplaintListByFid(string guid);
        /// <summary>
        /// 根据外键批量查询留言
        /// </summary>
        /// <param name="fidLList">外键集合</param>
        /// <returns></returns>
        List<Complaint> FindComplaintListByFidlist(List<string> fidlist);
        #endregion

        #region 审核模块
        /// <summary>
        /// 审核操作
        /// </summary>
        /// <param name="mode">审核结果 -1：删除 1：通过 2:拒绝</param>
        /// <param name="id">主键</param>
        void ReviewAction(int mode,Guid id);
        #endregion
        #region 统计模块
        /// <summary>
        /// 保存统计模型
        /// </summary>
        /// <param name="Statistic"></param>
        void SaveStatistic(Statistical Statistic);
        /// <summary>
        /// 查询所有统计模型
        /// </summary>
        /// <returns></returns>
        Task<List<StatisticModel>> FindStatisticList();
        #endregion
    }
}
