using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MongoDB.DAO
{
    public class MongoDbDao
    {
        private static string constr = @"mongodb://127.0.0.1:27017";
        private static MongoClient client = new MongoClient(constr);
        IMongoDatabase db = null;
        /// <summary>
        /// 有参构造,传入数据库名字
        /// </summary>
        /// <param name="DBName"></param>
        public MongoDbDao(string DBName)
        {
            db = client.GetDatabase(DBName);
        }
        /// <summary>
        /// 向库插入数据
        /// </summary>
        /// <typeparam name="T">文档对应模型</typeparam>
        /// <param name="model">模型实体</param>
        /// <param name="DocumentName">文档名称</param>
        public void Insert<T>(T model, string DocumentName)
        {
            IMongoCollection<BsonDocument> arti = db.GetCollection<BsonDocument>(DocumentName);
            string json = JsonConvert.SerializeObject(model);
            BsonDocument bd = BsonDocument.Parse(json);
            arti.InsertOne(bd);
        }
        /// <summary>
        /// 读取所有数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="DocumentName">文档名称</param>
        /// <returns></returns>
        public async Task<List<T>> SelectAllAsync<T>(string DocumentName)
        {
            List<T> list = new List<T>();
            await Task.Factory.StartNew(() => {
                IMongoCollection<BsonDocument> arti = db.GetCollection<BsonDocument>(DocumentName);
                List<BsonDocument> res = arti.Find(new BsonDocument()).ToList();
                res.ForEach(x => list.Add(BsonSerializer.Deserialize<T>(x)));
            });
            return list;
        }
    }
}
