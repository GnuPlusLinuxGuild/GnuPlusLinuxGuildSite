using Microsoft.AspNetCore.Mvc;
using Xunit;

using GnuPlusLinux.Controllers;
using GnuPlusLinux.Models.Forums;

namespace GnuPlusLinuxTestSuite
{
    public class ForumsControllerTest
    {
        private ForumsController _forumsController;

        public ForumsControllerTest()
        {
            _forumsController = new ForumsController();
        }

        [Fact]
        public void IndexActionReturnsIndexView()
        {
            ViewResult result = _forumsController.Index() as ViewResult;
            Assert.Equal("Index", result.ViewName);
        }

        [Fact]
        public void IndexActionReturnsCorrectViewModel()
        {
            ViewResult result = _forumsController.Index() as ViewResult;
            Assert.IsType<IndexViewModel>(result.Model);
        }
    }
}
