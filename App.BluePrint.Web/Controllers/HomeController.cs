using Abp.Web.Mvc.Authorization;
using System.Web.Mvc;

namespace App.BluePrint.Web.Controllers
{
    [AbpAuthorize]
    public class HomeController : ApplicationControllerBase
    {
        public ActionResult Index()
        { 
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}