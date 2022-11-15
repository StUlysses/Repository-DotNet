using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MongoDB.Model
{
    /// <summary>
    /// 统计的实体
    /// </summary>
    public class Statistical
    {
        //================基本情况===================
        /// <summary>
        /// 发病年龄 0:0-20，1:20-30，2:30-40，3:40-50，4:50-60，5:60-100
        /// </summary>
        public string MorbidityAge { get; set; }
        /// <summary>
        /// 性别
        /// 0：女，1:男
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// IBM体重指数 0--偏轻 <18.5, 1--18.5 <=中等 < 24, 2--24 <=偏重<28, 3--28<=超重
        /// </summary>
        public string IBM { get; set; }
        // =====================生活情况=========================
        /// <summary>
        /// 口味 0:偏甜,1:偏咸,2:偏辣
        /// </summary>
        public string Taste { get; set; }
        /// <summary>
        /// 吸烟史 0:一日一包, 1:三日一包 2:一周一包, 3:一周以上一包,4:不吸烟
        /// </summary>
        public string Smoking { get; set; }
        /// <summary>
        /// 饮酒史 0:经常,1:偶尔,2:从不
        /// </summary>
        public string Wine { get; set; }
        /// <summary>
        /// 咖啡史 0:经常,1:偶尔,2:从不
        /// </summary>
        public string Coffee { get; set; }
        /// <summary>
        /// 饮茶史 0:经常,1:偶尔,2:从不
        /// </summary>
        public string Tea { get; set; }
        /// <summary>
        /// 熬夜史 0:经常,1:偶尔,2:从不
        /// </summary>
        public string StayUpLate { get; set; }
        //===================病史情况===================
        /// <summary>
        /// 疾病史 0:高血压,1:低血糖,2:糖尿病
        /// </summary>
        public string[]? Illness { get; set; }
        /// <summary>
        /// 遗传史 亲属有无眩晕 0:无,1:有
        /// </summary>
        public string Inheritance { get; set; }
        /// <summary>
        /// 疫苗接种异常 0:无,1:有
        /// </summary>
        public string Vaccine { get; set; }
        /// <summary>
        /// 头部损伤 0:无,1:有
        /// </summary>
        public string HeadInjure { get; set; }
        //==================发作情况================
        /// <summary>
        /// 剧烈发作 0:数年一次,1:一年数次,2:一月数次,3:一周数次,4:一日数次
        /// </summary>
        public string AcuteMorbidity { get; set; }
        /// <summary>
        /// 轻微发作 0:经常,1:偶尔,2:从不
        /// </summary>
        public string SlightMorbidity { get; set; }
        /// <summary>
        /// 发病频繁时节
        /// </summary>
        public string SeasonMorbidity { get; set; }
        /// <summary>
        /// 发作伴耳鸣加重 0:无,1:有
        /// </summary>
        public string WithTinnitusExacerbation { get; set; }
        /// <summary>
        /// 发作伴冷汗 0:无,1:有
        /// </summary>
        public string WithColdSweat { get; set; }
        /// <summary>
        /// 发作伴肢体麻木 0:无,1:有
        /// </summary>
        public string WithBodyNumb { get; set; }
        /// <summary>
        /// 发作伴反胃 0:无,1:有
        /// </summary>
        public string WithAnaeolb { get; set; }
        /// <summary>
        /// 发作伴耳胀 0:无,1:有
        /// </summary>
        public string WithEarUp { get; set; }
        /// <summary>
        /// 发作伴耳闷 0:无,1:有
        /// </summary>
        public string WithEarFullness { get; set; }
        /// <summary>
        /// 发作伴腹泻 0:无,1:有
        /// </summary>
        public string WithDiarrhea { get; set; }
        //================平时异常情况================
        /// <summary>
        /// 耳胀 0:经常,1:偶尔,2:从不
        /// </summary>
        public string EarUp { get; set; }
        /// <summary>
        /// 耳闷 0:经常,1:偶尔,2:从不
        /// </summary>
        public string EarFullness { get; set; }
        /// <summary>
        /// 耳鸣 0:经常,1:偶尔,2:从不
        /// </summary>
        public string TinnitusExacerbation { get; set; }
        /// <summary>
        /// 睡眠障碍 0:经常,1:偶尔,2:从不
        /// </summary>
        public string SleepDisorders { get; set; }
        /// <summary>
        /// 讨厌尖锐声音 0:经常,1:偶尔,2:从不
        /// </summary>
        public string Hatetoshriek { get; set; }
        /// <summary>
        /// 头脑昏沉 0:经常,1:偶尔,2:从不
        /// </summary>
        public string Dazed { get; set; }
        //================缓解情况===================
        /// <summary>
        /// 目前是否缓解 0:无,1:有
        /// </summary>
        public string IsAnesis { get; set; }
        /// <summary>
        /// 日常哪些行为能减缓发作 0:保暖,1:进食,2:躺下3:吃药
        /// </summary>
        public string[]? AnesisAction { get; set; }
        /// <summary>
        /// 尝试过哪些针对眩晕的治疗
        /// </summary>
        public string? Therapy { get; set; }

        public DateTime? CreateTime { get; set; } = DateTime.Now;
    }
}
