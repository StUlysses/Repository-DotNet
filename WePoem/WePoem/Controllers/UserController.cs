using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interface;
using System;

namespace WePoem.Controllers
{
    public class UserController : Controller
    {
        private IUserService IUserService { get; }
        public UserController(IUserService iUserService)
        {
            IUserService = iUserService;
        }
        //登录注册页
        public IActionResult Index()
        {
            try
            {
                string uid = HttpContext.Session.GetString("UserID");
                ViewBag.UserID = uid ?? "null";
            }
            catch(Exception ex)
            {
                Tools.InsertPLog("登录注册页", ex.ToString(), "", Request);
            }
            return View();
        }
        //注册
        [HttpPost]
        public IActionResult Register(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User u = IUserService.AddUser(user);
                    if(u != null)
                    {
                        HttpContext.Session.SetString("UserName",u.UserName);
                        HttpContext.Session.SetString("UserID",u.UserID.ToString());
                        return Json(new { code = 200, msg = "注册成功" });
                    }
                }
            }
            catch(Exception ex)
            {
                Tools.InsertPLog("注册用户", ex.ToString(), "", Request);
            }
            return Json(new { code = 400, msg = "注册失败" });
        }
        //登录
        [HttpPost]
        public IActionResult Login(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User u = IUserService.Login(user);
                    if (u != null)
                    {
                        HttpContext.Session.SetString("UserName", u.UserName);
                        HttpContext.Session.SetString("UserID", u.UserID.ToString());
                        return Json(new {code=200,msg="登录成功"});
                    }
                }
            }
            catch(Exception ex)
            {
                Tools.InsertPLog("登录用户", ex.ToString(), "", Request);
            }
            return Json(new { code = 400, msg = "登录失败" });
        }
        //修改密码
        [HttpPost]
        public IActionResult EditUser(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string Uid = HttpContext.Session.GetString("UserID");
                    user.UserID = Guid.Parse(Uid);
                    string res = IUserService.UpdateUser(user);
                    if(res == "success")
                    {
                        return Json(new { code=200,msg="修改成功" });
                    }
                }
            }
            catch(Exception ex)
            {
                Tools.InsertPLog("修改密码",ex.ToString(),"",Request);
            }
            return Json(new { code = 400,msg = "修改失败" });
        }
        //退出登录
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserID");
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Index", "Poem","msg=以退出");
        }
    }
}