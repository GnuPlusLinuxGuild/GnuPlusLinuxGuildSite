using Microsoft.AspNetCore.Mvc;
using Xunit;

using GnuPlusLinux.Controllers;
using GnuPlusLinux.Models.Home;

namespace GnuPlusLinuxTestSuite
{
    public class HomeControllerTest
    {
        private HomeController _homeController;

        public HomeControllerTest()
        {
            _homeController = new HomeController();
        }

        [Fact]
        public void IndexActionReturnsIndexView()
        {
            ViewResult result = _homeController.Index() as ViewResult;
            Assert.Equal("Index", result.ViewName);
        }

        [Fact]
        public void IndexActionReturnsCorrectViewModel()
        {
            ViewResult result = _homeController.Index() as ViewResult;
            Assert.IsType<IndexViewModel>(result.Model);
        }

        [Fact]
        public void RegistrationActionReturnsRegistrationView()
        {
            ViewResult result = _homeController.Registration() as ViewResult;
            Assert.Equal("Registration", result.ViewName);
        }

        [Fact]
        public void RegistrationActionReturnsCorrectViewModel()
        {
            ViewResult result = _homeController.Registration() as ViewResult;
            Assert.IsType<RegistrationViewModel>(result.Model);
        }

        [Fact]
        public void LoginActionReturnsLoginView()
        {
            ViewResult result = _homeController.Login() as ViewResult;
            Assert.Equal("Login", result.ViewName);
        }

        [Fact]
        public void LoginActionReturnsCorrectViewModel()
        {
            ViewResult result = _homeController.Login() as ViewResult;
            Assert.IsType<LoginViewModel>(result.Model);
        }

        [Fact]
        public void ApplicationActionReturnsApplicationView()
        {
            ViewResult result = _homeController.Application() as ViewResult;
            Assert.Equal("Application", result.ViewName);
        }

        [Fact]
        public void ApplicationActionReturnsCorrectViewModel()
        {
            ViewResult result = _homeController.Application() as ViewResult;
            Assert.IsType<ApplicationViewModel>(result.Model);
        }

        [Fact]
        public void InformationActionReturnsInformationView()
        {
            ViewResult result = _homeController.Information() as ViewResult;
            Assert.Equal("Information", result.ViewName);
        }

        [Fact]
        public void InformationActionReturnsCorrectViewModel()
        {
            ViewResult result = _homeController.Information() as ViewResult;
            Assert.IsType<InformationViewModel>(result.Model);
        }
    }
}
