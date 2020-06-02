using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interface
{
    public interface IPoemService
    {
        /// <summary>
        /// 新增或保存诗歌
        /// </summary>
        /// <param name="poem"></param>
        /// <returns>success or fail</returns>
        string SavePoem(Poem poem);
        /// <summary>
        /// 根据作者查找诗歌
        /// </summary>
        /// <param name="uid">作者id</param>
        /// <returns></returns>
        List<Poem> FindPoemList(string uid);
        /// <summary>
        /// 通过ID查找单个诗歌
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        Poem FindPoemById(string pid);
        /// <summary>
        /// 正则匹配
        /// </summary>
        /// <param name="input">匹配字符串</param>
        /// <param name="pattern">匹配规则</param>
        /// <returns></returns>
        string RegexCat(string input, string pattern);
        /// <summary>
        /// 网络请求
        /// </summary>
        /// <param name="url">网址</param>
        /// <returns>网页</returns>
        string NetRequest(string url);
    }
}
