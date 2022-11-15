using log4net;
using Meniere.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System.Text;

namespace Meniere.Controllers
{
    public class HomeController : BaseController
    {
        /// <summary>
        /// 首页和吐槽页共有接口
        /// </summary>
        private IWordService IWordService { get; }
        private readonly ILog Log = LogManager.GetLogger(typeof(HomeController));
        public HomeController(IWordService iWordService)
        {
            IWordService = iWordService;
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="currentPage">当前页</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index(int currentPage)
        {
            ViewModel im = new ViewModel();
            try
            {
                currentPage = currentPage == 0 ? 1 : currentPage;
                im.CurrentPage = currentPage;
                im.ArticleList = IWordService.FindArticlesOrderByDate(currentPage,1);
                im.TotalPage = IWordService.FindTotalPage(1);
            }
            catch (Exception ex)
            {
                Log.Error("文章首页",ex);
            }
            return View(im);
        }
        /// <summary>
        /// 详情页
        /// </summary>
        /// <param name="guid">主键</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Info(string guid)
        {
            ViewModel im = new ViewModel();
            try
            {
                im.Article = IWordService.FindArticleByGuid(Guid.Parse(guid));
                im.ComplaintList = IWordService.FindComplaintListByFid(guid);
                im.User = HttpContext.Session.GetString("User");
                im.Email = HttpContext.Session.GetString("Email");
            }
            catch (Exception ex)
            {
                Log.Error("文章详情页", ex);
            }
            return View(im);
        }
        /// <summary>
        /// 文章编辑页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Creative()
        {
            ViewModel im = new ViewModel();
            im.User = HttpContext.Session.GetString("User");
            im.Email = HttpContext.Session.GetString("Email");
            return View(im);
        }
        /// <summary>
        /// 保存文章
        /// </summary>
        /// <param name="article">文章实体</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SaveArticle(Article article)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    article.Type = 1;
                    article.Result = 1;//初期文章不审核直接通过
                    IWordService.SaveArticle(article);
                    HttpContext.Session.SetString("User", article.Author);
                    HttpContext.Session.SetString("Email", article.AuthorEmail);
                    return Json(new { code = 200, msg = article.Guid });
                }
            }
            catch(Exception ex)
            {
                Log.Error("保存文章",ex);
            }
            return Json(new { code = 400, msg = "保存失败" });
        }
        /// <summary>
        /// 异步保存图片
        /// </summary>
        /// <param name="files"></param>
        [HttpPost]
        public async Task SaveArticleImgAsync(string id)
        {
            try
            {
                //获取Form提交的文件
                List<IFormFile>? files = Request.Form.Files as List<IFormFile>;
                if(files?.Count > 0)
                {
                    string img = "-";
                    //拿到wwwroot地址
                    string rootPath = Directory.GetCurrentDirectory() + "/wwwroot";
                    string filePath = String.Format("/Upload/Image/{0}/{1}", DateTime.Now.Year, DateTime.Now.Month);
                    //保存目录不存在就创建这个目录
                    if (!Directory.Exists(rootPath + filePath))
                    {
                        Directory.CreateDirectory(rootPath + filePath);
                    }
                    StringBuilder sb = new StringBuilder();
                    foreach (var file in files)
                    {
                        int count = file.FileName.Split('.').Length;//统计.将名字分为几个部分
                        string exp = file.FileName.Split('.')[count - 1];//最后一部分为后缀名
                        
                        //在指定目录创建文件
                        string fileName = String.Format(@"{0}/{1}.{2}",
                            filePath, Guid.NewGuid().ToString(), exp);//文件名
                        using (var stream = new FileStream(rootPath + fileName, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        sb.Append(fileName + "|");
                    }
                    img = sb.Length > 0 ? sb.Replace(@"\","/").ToString() : "-";
                    //更新文章实体
                    Article arti = new Article()
                    {
                        Guid = Guid.Parse(id),
                        Attachment = img,
                    };
                    await IWordService.UpdateArticle(arti);
                }
            }
            catch (Exception ex)
            {
                Log.Error("保存文章图片", ex);
            }
        }

        /// <summary>
        /// 保存留言
        /// </summary>
        /// <param name="complaint">留言实体</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SaveMark(Complaint complaint)
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
                    return Json(new { 
                        code = 200, 
                        msg = "保存成功",
                        author=complaint.Author,
                        date=complaint.Date.ToString("yyyy-MM-dd"),
                        detail=complaint.Detail
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
