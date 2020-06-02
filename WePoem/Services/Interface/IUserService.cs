using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interface
{
    public interface IUserService
    {
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <returns>用户实体</returns>
        User AddUser(User user);
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="user">登录的用户</param>
        /// <returns>用户实体</returns>
        User Login(User user);
        /// <summary>
        /// 更新User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>success or fail</returns>
        string UpdateUser(User user);
    }
}
