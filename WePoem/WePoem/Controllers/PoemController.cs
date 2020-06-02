using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interface;
using System;
using WePoem.Models;
using Microsoft.AspNetCore.Http;


namespace WePoem.Controllers
{
    public class PoemController : Controller
    {
        private IPoemService IPoemService { get; }
        public PoemController(IPoemService iPoemService)
        {
            IPoemService = iPoemService;
        }
        //首页
        public IActionResult Index()
        {
            ViewModel vm = new ViewModel();
            try
            {
                vm.Msg = Request.Query["msg"];
                vm.UserID = HttpContext.Session.GetString("UserID");
                //每日诗歌
                Poem poem = new Poem();
                string url = "http://www.zgshige.com";
                string html = IPoemService.NetRequest(url);
                string Sel1 = IPoemService.RegexCat(html, "<a title=\".{4}\" target=\"_blank\" href=\"http://www.zgshige.com/c/.*.shtml\">.{4}</a>");
                //匹配标题
                string title = IPoemService.RegexCat(Sel1, ">.*</a>");
                poem.Title = title.Substring(1, title.Length - 5);
                //内容
                url = IPoemService.RegexCat(Sel1, "http://www.zgshige.com/c/.*.shtml");
                html = IPoemService.NetRequest(url);
                string con = IPoemService.RegexCat(html, "<div class=\"m-lg font14\"><p>.*</p></div>");
                poem.Content = con.Substring(33, (con.Length - 53)).Replace("<br/>", "###***");
                vm.Poem = poem;
            }
            catch(Exception ex)
            {
                Tools.InsertPLog("进入首页失败", ex.ToString(), "", Request);
            }
            return View(vm);
        }
        //创作页面
        [HttpGet]
        public IActionResult Creative()
        {
            ViewModel vm = new ViewModel();
            try
            {
                string pid = Request.Query["pid"];
                if (!string.IsNullOrEmpty(pid))
                {
                    Poem poem = IPoemService.FindPoemById(pid);
                    vm.Poem = poem;
                }
            }
            catch (Exception ex)
            {
                Tools.InsertPLog("读取诗歌失败", ex.ToString(), "", Request);
            }
            return View(vm);
        }
        //保存诗歌
        [HttpPost]
        public IActionResult Creative(Poem poem,string id)
        {
            try
            {
                string res = null;
                int code = 200;
                //string id = Request.Query["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    poem.PoemID = Guid.Parse(id);
                    code = 201;
                }
                if (ModelState.IsValid)
                {
                    poem.Auther = HttpContext.Session.GetString("UserName");
                    poem.AutherID = Guid.Parse(HttpContext.Session.GetString("UserID"));
                    res = IPoemService.SavePoem(poem);
                }
                if (res == "success")
                {
                    return Json(new { code, msg = "发布成功" });
                }
            }
            catch (Exception ex)
            {
                Tools.InsertPLog("保存诗歌失败", ex.ToString(), "", Request);
            }
            return Json(new { code = 400, msg = "发布失败" });
        }
        //诗集页面
        public IActionResult PoemCollection()
        {
            ViewModel vm = new ViewModel();
            try
            {
                string uid = HttpContext.Session.GetString("UserID");
                var list = IPoemService.FindPoemList(uid);
                vm.PoemList = list;
            }
            catch(Exception ex)
            {
                Tools.InsertPLog("读取诗集失败", ex.ToString(), "", Request);
            }
            return View(vm);
        }
    }
}