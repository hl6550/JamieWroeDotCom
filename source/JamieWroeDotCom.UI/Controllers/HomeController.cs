namespace JamieWroeDotCom.UI.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult About()
        {
            return View("About");
        }

        public ActionResult Contact()
        {
            return View("Contact");
        }

        public ActionResult Portfolio()
        {
            return View("Portfolio");
        }

    }
}