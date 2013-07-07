namespace JamieWroeDotCom.UI.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View("Index");
        }

    }
}