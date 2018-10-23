using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;

using GnuPlusLinux.Controllers;
using GnuPlusLinux.Models.Member;
using GnuPlusLinuxDAL;
using System.Collections.Generic;
using System.Linq;
using Moq;

namespace GnuPlusLinuxTestSuite
{
    public class MemberControllerTest
    {
        private AccountContext _accountContext;
        private MemberController _memberController;
        private List<Account> _allTestAccounts;

        public MemberControllerTest()
        {
            IConfiguration config = new ConfigurationBuilder().Build();

            DbContextOptions<AccountContext> DbContextOptions =
                new DbContextOptionsBuilder<AccountContext>()
                .UseSqlServer("connectionString")
                .Options;

            _allTestAccounts = new List<Account>
            {
                new Account
                {
                    accountId = 1,
                    username = "SA",
                    password = "TestAdmin",
                    confirmPw = "TestAdmin",
                    email = "test@gmail.com",
                    isAdmin = true,
                    isMod = true,
                },
                new Account
                {
                    accountId = 2,
                    username = "Second User",
                    password = "1234",
                    confirmPw = "w1234estAdmin",
                    email = "test@test.test",
                    isAdmin = true,
                    isMod = true,
                }
            };

            _accountContext = new AccountContext(DbContextOptions);

            _accountContext.accounts = 
                GetQueryableMockDbSet<Account>(_allTestAccounts);

            _memberController = new MemberController(_accountContext);
        }

        private static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) 
            where T : class
        {
            var queryable = sourceList.AsQueryable();

            Mock<DbSet<T>> dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider)
                .Returns(queryable.Provider);

            dbSet.As<IQueryable<T>>().Setup(m => m.Expression)
                .Returns(queryable.Expression);

            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType)
                .Returns(queryable.ElementType);

            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator())
                .Returns(() => queryable.GetEnumerator());

            dbSet.Setup(d => d.Add(It.IsAny<T>()))
                .Callback<T>((s) => sourceList.Add(s));

            return dbSet.Object;
        }

        [Theory]
        [InlineData(null)]
        [InlineData(2)]
        public void RegisterGetActionReturnsRegisterView(int? id)
        {
            ViewResult result = _memberController.Register(id) as ViewResult;
            Assert.Equal("Register", result.ViewName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(1)]
        public void IndexActionReturnsCorrectViewModel(int? id)
        {
            ViewResult result = _memberController.Register(id) as ViewResult;
            Assert.IsType<RegistrationViewModel>(result.Model);
        }
    }
}
