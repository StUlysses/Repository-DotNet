using log4net;
using Microsoft.AspNetCore.Mvc;
using Models.MongoDB.Model;
using Services;

namespace Meniere.Controllers
{
    public class StatisticalController : BaseController
    {
        private IWordService IWordService { get; }
        private readonly ILog Log = LogManager.GetLogger(typeof(ComplaintController));
        public StatisticalController(IWordService iWordService)
        {
            IWordService = iWordService;
        }
        /// <summary>
        /// 统计首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 参与统计页面
        /// </summary>
        /// <returns></returns>
        public IActionResult JoinStatistic()
        {
            return View();
        }
        /// <summary>
        /// 保存统计
        /// </summary>
        /// <param name="model">统计模型</param>
        /// <returns></returns>
        public IActionResult SaveStatistical(Statistical model)
        {
            try
            {
                IWordService.SaveStatistic(model);
            }
            catch (Exception ex)
            {
                Log.Error("保存统计", ex);
            }
            return RedirectToAction("Index");
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetStatisticModel()
        {
            try
            {
                List<StatisticModel> StatisticList = await IWordService.FindStatisticList();
                #region json处理
                var MorbidityAgeJson = StatisticList.GroupBy(x => x.MorbidityAge)
                    .Select(x => new
                    {
                        name = x.Key,
                        value = x.Count()
                    });
                var GenderJson = StatisticList.GroupBy(x => x.Gender)
                    .Select(x => new
                    {
                        name = x.Key,
                        value = x.Count()
                    });
                var IBMJson = StatisticList.GroupBy(x => x.IBM)
                    .Select(x => new
                    {
                        name = x.Key,
                        value = x.Count()
                    });
                var TasteJson = StatisticList.GroupBy(x => x.Taste)
                    .Select(x => new
                    {
                        name = x.Key,
                        value = x.Count()
                    });
                var SmokingJson = StatisticList.GroupBy(x => x.Smoking)
                    .Select(x => new
                    {
                        name = x.Key,
                        value = x.Count()
                    });
                var WineJson = StatisticList.GroupBy(x => x.Wine)
                    .Select(x => new
                    {
                        name = x.Key,
                        value = x.Count()
                    });
                var CoffeeJson = StatisticList.GroupBy(x => x.Coffee)
                    .Select(x => new
                    {
                        name = x.Key,
                        value = x.Count()
                    });
                var TeaJson = StatisticList.GroupBy(x => x.Tea)
                    .Select(x => new
                    {
                        name = x.Key,
                        value = x.Count()
                    });
                var StayUpLateJson = StatisticList.GroupBy(x => x.StayUpLate)
                    .Select(x => new
                    {
                        name = x.Key,
                        value = x.Count()
                    });
                var IllnessJson = StatisticList.GroupBy(x => x.Illness?.Length ==0 ? "无" : string.Join("-", x.Illness))
                    .Select(x => new
                    {
                        name = x.FirstOrDefault()?.Illness,
                        value = x.Count(),
                    });
                var InheritanceJson = StatisticList.GroupBy(x => x.Inheritance)
                    .Select(x => new
                    {
                        name = x.Key,
                        value = x.Count()
                    });
                var VaccineJson = StatisticList.GroupBy(x => x.Vaccine)
                    .Select(x => new
                    {
                        name = x.Key,
                        value = x.Count()
                    });
                var HeadInjureJson = StatisticList.GroupBy(x => x.HeadInjure)
                    .Select(x => new
                    {
                        name = x.Key,
                        value = x.Count()
                    });
                var AcuteMorbidityJson = StatisticList.GroupBy(x => x.AcuteMorbidity)
                    .Select(x => new
                    {
                        name = x.Key,
                        value = x.Count()
                    });
                var SlightMorbidityJson = StatisticList.GroupBy(x => x.SlightMorbidity)
                    .Select(x => new
                    {
                        name = x.Key,
                        value = x.Count()
                    });
                var SeasonMorbidityJson = StatisticList.GroupBy(x => x.SeasonMorbidity)
                    .Select(x => new
                    {
                        name = x.Key,
                        value = x.Count()
                    });
                var WithTinnitusExacerbationJson = StatisticList.GroupBy(x => x.WithTinnitusExacerbation)
                    .Select(x => new
                    {
                        name = x.Key,
                        value = x.Count()
                    });
                var WithColdSweatJson = StatisticList.GroupBy(x => x.WithColdSweat)
                    .Select(x => new
                    {
                        name = x.Key,
                        value = x.Count()
                    });
                var WithBodyNumbJson = StatisticList.GroupBy(x => x.WithBodyNumb)
                    .Select(x => new
                    {
                        name = x.Key,
                        value = x.Count()
                    });
                var WithAnaeolbJson = StatisticList.GroupBy(x => x.WithAnaeolb)
                    .Select(x => new
                    {
                        name = x.Key,
                        value = x.Count()
                    });
                var WithEarUpJson = StatisticList.GroupBy(x => x.WithEarUp)
                    .Select(x => new
                    {
                        name = x.Key,
                        value = x.Count()
                    });
                var WithEarFullnessJson = StatisticList.GroupBy(x => x.WithEarFullness)
                    .Select(x => new
                    {
                        name = x.Key,
                        value = x.Count()
                    });
                var WithDiarrheaJson = StatisticList.GroupBy(x => x.WithDiarrhea)
                    .Select(x => new
                    {
                        name = x.Key,
                        value = x.Count()
                    });
                var EarUpJson = StatisticList.GroupBy(x => x.EarUp)
                    .Select(x => new
                    {
                        name = x.Key,
                        value = x.Count()
                    });
                var EarFullnessJson = StatisticList.GroupBy(x => x.EarFullness)
                    .Select(x => new
                    {
                        name = x.Key,
                        value = x.Count()
                    });
                var TinnitusExacerbationJson = StatisticList.GroupBy(x => x.TinnitusExacerbation)
                    .Select(x => new
                    {
                        name = x.Key,
                        value = x.Count()
                    });
                var SleepDisordersJson = StatisticList.GroupBy(x => x.SleepDisorders)
                    .Select(x => new
                    {
                        name = x.Key,
                        value = x.Count()
                    });
                var HatetoshriekJson = StatisticList.GroupBy(x => x.Hatetoshriek)
                    .Select(x => new
                    {
                        name = x.Key,
                        value = x.Count()
                    });
                var DazedJson = StatisticList.GroupBy(x => x.Dazed)
                    .Select(x => new
                    {
                        name = x.Key,
                        value = x.Count()
                    });
                #endregion
                return Json(new
                {
                    data = new {
                        MorbidityAgeJson,
                        GenderJson,
                        IBMJson,
                        TasteJson,
                        SmokingJson,
                        WineJson,
                        CoffeeJson,
                        TeaJson,
                        StayUpLateJson,
                        IllnessJson,
                        InheritanceJson,
                        VaccineJson,
                        HeadInjureJson,
                        AcuteMorbidityJson,
                        SlightMorbidityJson,
                        SeasonMorbidityJson,
                        WithTinnitusExacerbationJson,
                        WithColdSweatJson,
                        WithBodyNumbJson,
                        WithAnaeolbJson,
                        WithEarUpJson,
                        WithEarFullnessJson,
                        WithDiarrheaJson,
                        EarUpJson,
                        EarFullnessJson,
                        TinnitusExacerbationJson,
                        SleepDisordersJson,
                        HatetoshriekJson,
                        DazedJson
                    },
                    code = 200
                });
            }
            catch(Exception ex) {
                Log.Error("获取统计模型", ex);
            }
            return Json(new { code = 400, msg = "获取统计模型" });
        }
    }
}
