using Microsoft.AspNetCore.Http;
using Models;
using System.Text;

namespace WePoem
{
    public class Tools
    {
        /// <summary>
        /// 保存log
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="content">exception内容</param>
        /// <param name="sql"></param>
        /// <param name="request"></param>
        public static void InsertPLog(string title, string content, string sql, HttpRequest request)
        {
            string url = new StringBuilder()
                .Append(request.Scheme)
                .Append("://")
                .Append(request.Host)
                .Append(request.PathBase)
                .Append(request.Path)
                .Append(request.QueryString).ToString();
            using (PoemDbContext db = new PoemDbContext())
            {
                PLog pl = new PLog()
                {
                    Title = title,
                    Content = content,
                    SQL = sql,
                    URL = url
                };
                db.PLog.Add(pl);
                db.SaveChanges();
            }
        }
    }
}
