using Models;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class UserServices : IUserService
    {
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <returns>用户实体</returns>
        public User AddUser(User user)
        {
            try
            {
                
                using (PoemDbContext db = new PoemDbContext())
                {
                    user.UserID = Guid.NewGuid();
                    db.User.Add(user);
                    int res = db.SaveChanges();
                    return res > 0 ? user : null;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="user">登录的用户</param>
        /// <returns>用户实体</returns>
        public User Login(User user)
        {
            try
            {
                using(PoemDbContext db = new PoemDbContext())
                {
                    User u = db.User.Where(o => o.UserName == user.UserName && o.Password == user.Password).FirstOrDefault();
                    return u ?? null;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 跟新User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>success or fail</returns>
        public string UpdateUser(User user)
        {
            try
            {
                int res = 0;
                using (PoemDbContext db = new PoemDbContext())
                {
                    User u = db.User.Find(user.UserID);
                    if(u != null)
                    {
                        u.UserName = user.UserName;
                        u.Password = user.Password;
                        res = db.SaveChanges();
                    }
                    return res > 0 ? "success" : "fail";
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
