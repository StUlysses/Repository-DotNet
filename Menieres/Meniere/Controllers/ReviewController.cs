using log4net;
using Meniere.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Meniere.Controllers
{
    public class ReviewController : BaseController
    {
        /// <summary>
        /// 首页和吐槽页共有接口
        /// </summary>
        private IWordService IWordService { get; }
        private readonly ILog Log = LogManager.GetLogger(typeof(ReviewController));
        public ReviewController(IWordService iWordService)
        {
            IWordService = iWordService;
        }
        /// <summary>
        /// 审核首页
        /// </summary>
        /// <param name="currentPage">当前页</param>
        /// <param name="result">-1：已删除 0：未通过(初始值) 1：已通过 2:已拒绝</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index(int currentPage, int result = 0)
        {
            ViewModel im = new ViewModel();
            try
            {
                currentPage = currentPage == 0 ? 1 : currentPage;
                im.CurrentPage = currentPage;
                im.ArticleList = IWordService.FindArticlesOrderByDate(currentPage, 1, result);
                im.TotalPage = IWordService.FindTotalPage(1, result);
            }
            catch (Exception ex)
            {
                Log.Error("审核页",ex);
            }
            return View(im);
        }
        /// <summary>
        /// 审核操作
        /// </summary>
        /// <param name="type">审核类型 1 文章 2 游戏</param>
        /// <param name="mode">审核结果 -1：删除 1：通过 2:拒绝</param>
        /// <param name="author">作者</param>
        /// <param name="email">邮箱</param>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ReviewAct(int type,int mode,string guid,string author,string email)
        {
            try
            {
                HttpContext.Session.SetString("User", author);
                HttpContext.Session.SetString("Email", email);
                IWordService.ReviewAction(mode,Guid.Parse(guid));
            }
            catch (Exception ex)
            {
                Log.Error("审核操作", ex);
            }
            return Redirect(string.Format("/Review/Index?currentPage=1&result=0&type={0}",type));
        }

        /// <summary>
        /// 进入文章审核页
        /// </summary>
        /// <param name="guid">文章GUID</param>
        /// <returns></returns>
        public IActionResult ActicleReview(string guid)
        {
            ViewModel im = new ViewModel();
            try
            {
                im.Article = IWordService.FindArticleByGuid(Guid.Parse(guid));
                im.User = HttpContext.Session.GetString("User");
                im.Email = HttpContext.Session.GetString("Email");
            }
            catch (Exception ex)
            {
                Log.Error("进入文章审核页", ex);
            }
            return View(im);
        }
    }
}
