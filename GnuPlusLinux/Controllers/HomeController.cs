using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

using GnuPlusLinux.Models;
using GnuPlusLinux.Models.Home;

namespace GnuPlusLinux.Controllers
{
    public class HomeController : Controller
    {
        // Page Titles
        private const string HomePageTitle = "Home";
        private const string InformationPageTitle = "Information";
        private const string RegistrationPageTitle = "Registration";
        private const string ApplicationPageTitle = "Application";
        private const string LoginPageTitle = "Login";

        // Dummy Test
        private const string ParisDummyText = "Paris is the capital of France.";
        private const string TokyoDummyText = "Tokyo is the capital of Japan.";

        [HttpGet]
        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel(HomePageTitle);
            return View("Index", model);
        }

        [HttpGet]
        public IActionResult Registration()
        {
            RegistrationViewModel model =
                new RegistrationViewModel(RegistrationPageTitle);

            return View("Registration", model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginViewModel model = new LoginViewModel(LoginPageTitle);
            return View("Login", model);
        }

        [HttpGet]
        public IActionResult Application()
        {
            ApplicationViewModel model = 
                new ApplicationViewModel(ApplicationPageTitle);

            model.message = "GNU + Linux application";

            return View("Application", model);
        }

        [HttpGet]
        public IActionResult Information()
        {
            InformationViewModel model =
                new InformationViewModel(InformationPageTitle);

            model.welcome = "Our vision: Be a guild that values loyalty," +
                " community, friendships and \"fun\" more than" +
                " \"progression\" or \"competition.\" We don't know if we" +
                " will make it to level 60 or how Blizzard will develop" +
                " Classic WoW. We might get to level 10 and get bored, or" +
                " we might get obsessed and attempt to get world firsts!" +
                " (Probably won't happen).\n\nHowever, we plan to participate" +
                " in this grand adventure and see where we end up." +
                " Progression may not be the primary focus of this guild" +
                " right now, but it could be! This depends upon the coming" +
                " weeks and months and how we grow as a community.";

            model.charter = ParisDummyText;
            model.rules = TokyoDummyText;
            model.loot = ParisDummyText;
            model.addons = TokyoDummyText;
            model.recruitment = ParisDummyText;

            return View("Information", model);
        }

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None,
            NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id 
                ?? HttpContext.TraceIdentifier });
        }
    }
}
