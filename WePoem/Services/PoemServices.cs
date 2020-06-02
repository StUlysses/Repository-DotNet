using Models;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Services
{
    public class PoemServices : IPoemService
    {
        /// <summary>
        /// 新增或保存诗歌
        /// </summary>
        /// <param name="poem"></param>
        /// <returns>success or fail</returns>
        public string SavePoem(Poem poem)
        {
            try
            {
                using(PoemDbContext db = new PoemDbContext())
                {
                    if (poem.PoemID == Guid.Parse("00000000-0000-0000-0000-000000000000"))//无id传进来，是新增
                    {
                        poem.PoemID = Guid.NewGuid();
                        db.Poem.Add(poem);
                    }
                    else//保存
                    {
                        var p = db.Poem.Find(poem.PoemID);
                        p.Title = poem.Title;
                        p.Content = poem.Content;
                    }
                    int res = db.SaveChanges();
                    return res > 0 ? "success" : "fail";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 根据作者查找诗歌
        /// </summary>
        /// <param name="uid">作者id</param>
        /// <returns></returns>
        public List<Poem> FindPoemList(string uid)
        {
            try
            {
                using (PoemDbContext db = new PoemDbContext())
                {
                    Guid AutherId = Guid.Parse(uid);
                    List<Poem> list = db.Poem.Where(o => o.AutherID == AutherId).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 通过ID查找单个诗歌
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public Poem FindPoemById(string pid)
        {
            try
            {
                using (PoemDbContext db = new PoemDbContext())
                {
                    var poem = db.Poem.Find(Guid.Parse(pid));
                    return poem;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 正则匹配
        /// </summary>
        /// <param name="input">匹配字符串</param>
        /// <param name="pattern">匹配规则</param>
        /// <returns></returns>
        public string RegexCat(string input, string pattern)
        {
            MatchCollection res = Regex.Matches(input, pattern);
            foreach (var text in res)
            {
                return text.ToString();
            }
            return "FAIL";
        }
        /// <summary>
        /// 网络请求
        /// </summary>
        /// <param name="url">网址</param>
        /// <returns>网页</returns>
        public string NetRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.KeepAlive = false;
            request.Timeout = 30000;
            request.Method = "GET";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:76.0) Gecko/20100101 Firefox/76.0";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode != HttpStatusCode.OK)
                Console.WriteLine("ERROR");

            using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                string con = sr.ReadToEnd();
                return con;
            }
        }
    }
}
