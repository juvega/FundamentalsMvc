using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetFundamentals.Web
{
    public class ExceptionControl :
        ActionFilterAttribute, IExceptionFilter
    {
        private static ILog Log { get; set; }
        ILog log = LogManager.GetLogger
            (
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
            );
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            log.Error(filterContext.Exception);

            var controller = filterContext.RouteData.Values["controller"].ToString();
            var action = filterContext.RouteData.Values["action"].ToString();
            var model = new HandleErrorInfo(filterContext.Exception,
                                            controller,
                                            action);
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml",
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                TempData = filterContext.Controller.TempData
            };
        }
    }
}