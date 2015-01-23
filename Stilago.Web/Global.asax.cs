using System;
using Abp.Dependency;
using Abp.Web;
using Castle.Facilities.Logging;
using System.Web.Http;
using Elmah.Contrib.WebApi;

namespace Stilago.Web
{
    public class MvcApplication : AbpWebApplication
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configuration.Filters.Add(new ElmahHandleErrorApiAttribute());

            IocManager.Instance.IocContainer.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("log4net.config"));
            base.Application_Start(sender, e);
        }
    }
}
