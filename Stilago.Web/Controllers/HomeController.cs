using System.Web.Mvc;

namespace Stilago.Web.Controllers
{
    public class HomeController : StilagoControllerBase
    {
        public ActionResult Index()
        { 
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}