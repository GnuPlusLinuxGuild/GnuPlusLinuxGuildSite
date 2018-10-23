using Microsoft.AspNetCore.Mvc;

using GnuPlusLinux.Models.Forums;

namespace GnuPlusLinux.Controllers
{
    public class ForumsController : Controller
    {
        // Page Titles
        private const string IndexTitle = "Forums";

        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel(IndexTitle);
            model.message = "Welcome to the GNU Plus Linux Fourms";

            return View("Index", model);
        }
    }
}