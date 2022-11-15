using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Meniere.Controllers
{
    public class BaseController : Controller
    {
        private readonly ILog Log = LogManager.GetLogger(typeof(BaseController));
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //拿到路由信息
            string? Controller = ((object[])context.RouteData.Values.Values)[0].ToString();
            string? Action = ((object[])context.RouteData.Values.Values)[1].ToString();
            //拿到ip
            string? Address = context.HttpContext.Connection.LocalIpAddress?.ToString();
            string? Port = context.HttpContext.Connection.LocalPort.ToString();

            Log.Info(string.Format("{0}:{1}——{2}/{3}",Address,Port,Controller,Action));

            base.OnActionExecuting(context);
        }

    }
}
