using Models;
using Services;
using System;
using Xunit;

namespace ServiceTest
{
    public class PoemServiceTest
    {
        [Fact]
        public void RegexTest()
        {
            PoemServices ps = new PoemServices();
            Poem poem = new Poem();
            string url = "http://www.zgshige.com";
            string html = ps.NetRequest(url);
            string Sel1 = ps.RegexCat(html, "<a title=\".{4}\" target=\"_blank\" href=\"http://www.zgshige.com/c/.*.shtml\">.{4}</a>");
            //ƥ�����
            string title = ps.RegexCat(Sel1, ">.*</a>");
            poem.Title = title.Substring(1, title.Length - 5);
            //����
            url = ps.RegexCat(Sel1, "http://www.zgshige.com/c/.*.shtml");
            html = ps.NetRequest(url);
            string con = ps.RegexCat(html, "<div class=\"m-lg font14\"><p>.*</p></div>");
            poem.Content = con.Substring(33, (con.Length - 53)).Replace("<br/>", "###***");

            Assert.Contains("�ڿ���ɽ",poem.Title);
        }
    }
}
