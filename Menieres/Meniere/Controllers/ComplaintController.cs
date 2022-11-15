using log4net;
using Meniere.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Meniere.Controllers
{
    public class ComplaintController : BaseController
    {
        /// <summary>
        /// 首页和吐槽页共有接口
        /// </summary>
        private IWordService IWordService { get; }
        private readonly ILog Log = LogManager.GetLogger(typeof(ComplaintController));
        public ComplaintController(IWordService iWordService)
        {
            IWordService = iWordService;
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="currentPage">当前页码</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index(int currentPage)
        {
            ViewModel cm = new ViewModel();
            try
            {
                currentPage = currentPage == 0 ? 1 : currentPage;
                cm.CurrentPage = currentPage;
                cm.User = HttpContext.Session.GetString("User");
                cm.Email = HttpContext.Session.GetString("Email");
                cm.TotalPage = IWordService.FindTotalPage(2);
                //文章集合
                List<Article> artiList = IWordService.FindArticlesOrderByDate(currentPage, 2);
                //收集所有外键
                List<string> fidlist = artiList.Select(b => b.Guid.ToString()).ToList();
                //评论集合
                List<Complaint> comList = IWordService.FindComplaintListByFidlist(fidlist);
                List<ArticleModel> amList = new List<ArticleModel>();
                //把文章和评论合并
                foreach (Article article in artiList)
                {
                    ArticleModel am = new ArticleModel()
                    {
                        Guid = article.Guid,
                        Aid = article.Aid,
                        Title = article.Title,
                        Author = article.Author,
                        AuthorEmail = article.AuthorEmail,
                        Content = article.Content,
                        Date = article.Date,
                        ComplaintList = comList.Where(b => b.Fid.Equals(article.Guid.ToString()))
                        .OrderByDescending(b => b.Date).ToList()
                    };
                    amList.Add(am);
                }
                cm.ArticleModelList = amList.OrderByDescending(b => b.Date).ToList();

            }
            catch (Exception ex)
            {
                Log.Error("吐槽首页",ex);
            }
            return View(cm);
        }
        /// <summary>
        /// 保存文章  
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SaveComplaint(Article article)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    article.Type = 2;
                    article.Result = 1;//先直接给通过，II期在做审核
                    IWordService.SaveArticle(article);
                    HttpContext.Session.SetString("User", article.Author);
                    HttpContext.Session.SetString("Email", article.AuthorEmail);
                    return Json(new { code = 200, msg = "保存成功" });
                }
            }
            catch (Exception ex)
            {
                Log.Error("保存吐槽", ex);
            }
            return Json(new { code = 400, msg = "保存失败" });
        }

        public IActionResult SaveRemark(Complaint complaint)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    complaint.Type = 1;
                    complaint.Result = 1;//先直接给通过，II期在做审核
                    complaint.mode = 1;
                    IWordService.SaveComplaint(complaint);
                    HttpContext.Session.SetString("User", complaint.Author);
                    HttpContext.Session.SetString("Email", complaint.AuthorEmail);
                    return Json(new
                    {
                        code = 200,
                        msg = "保存成功",
                        author = complaint.Author,
                        date = complaint.Date.ToString("yyyy-MM-dd"),
                        detail = complaint.Detail
                    });
                }
            }
            catch (Exception ex)
            {
                Log.Error("保存留言", ex);
            }
            return Json(new { code = 400, msg = "保存失败" });
        }
    }
}
