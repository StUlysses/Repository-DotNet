using Models;
using Models.Entities;
using Models.MongoDB.DAO;
using Models.MongoDB.Model;

namespace Services
{
    public class WordService : IWordService
    {
        public List<Article> FindArticlesOrderByDate(int currentPage,int type,int result = 1)
        {
            List<Article> list = new List<Article>();
            using (MeniereDBContext db = new MeniereDBContext())
            {
                //只查询已通过审核
                list = db.Article.Where(b => b.Result == result && b.Type == type)
                    .OrderByDescending(b => b.Date)
                    .Skip((currentPage - 1) * 20)
                    .Take(20).ToList();
            }
            return list;
        }

        public List<Complaint> FindComplaintListByFid(string guid)
        {
            List<Complaint> list = new List<Complaint>();
            using (MeniereDBContext db = new MeniereDBContext())
            {
                list = db.Complaint.Where(b => b.Result == 1 && guid.Equals(b.Fid))
                    .OrderByDescending(b => b.Date).ToList();
            }
            return list;
        }

        public List<Complaint> FindComplaintListByFidlist(List<string> fidlist)
        {
            List<Complaint> list = new List<Complaint>();
            using (MeniereDBContext db = new MeniereDBContext())
            {
                list = db.Complaint.Where(b => b.Result == 1 && fidlist.Contains(b.Fid))
                    .OrderByDescending(b => b.Date).ToList();
            }
            return list;
        }

        public int FindTotalPage(int type, int result = 1)
        {
            int totalPage = 1;
            using (MeniereDBContext db = new MeniereDBContext())
            {
                int total = db.Article.Count(b => b.Result == result && b.Type == type);
                totalPage = total / 20 + (total % 20 > 0 ? 1 : 0);
            }
            return totalPage;
        }

        public Article FindArticleByGuid(Guid guid)
        {
            Article art = new Article();
            using (MeniereDBContext db = new MeniereDBContext())
            {
                art = db.Article.Find(guid);
            }
            return art;
        }

        public void SaveArticle(Article article)
        {
            using (MeniereDBContext db = new MeniereDBContext())
            {
                db.Article.Add(article);
                db.SaveChanges();
            }
        }

        public void SaveComplaint(Complaint complaint)
        {
            using (MeniereDBContext db = new MeniereDBContext())
            {
                db.Complaint.Add(complaint);
                db.SaveChanges();
            }
        }

        public void ReviewAction(int mode, Guid id)
        {
            using (MeniereDBContext db = new MeniereDBContext())
            {
                Article arti = db.Article.Find(id);
                arti.Result = mode;
                db.Article.Update(arti);
                db.SaveChanges();
            }
        }

        public void SaveStatistic(Statistical Statistic)
        {
            MongoDbDao mdd = new("Meniere");
            mdd.Insert(Statistic, "Statistic");
        }

        public async Task<List<StatisticModel>> FindStatisticList()
        {
            MongoDbDao mdd = new("Meniere");
            return await mdd.SelectAllAsync<StatisticModel>("Statistic");
        }

        public async Task UpdateArticle(Article article)
        {
            using (MeniereDBContext db = new MeniereDBContext())
            {
                Article arti = db.Article.Find(article.Guid);
                arti.Attachment = article.Attachment;
                db.Article.Update(arti);
                await db.SaveChangesAsync();
            }
        }
    }
}
