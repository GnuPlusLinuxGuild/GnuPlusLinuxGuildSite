using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Xunit;

using GnuPlusLinuxDAL;

namespace GnuPlusLinuxTestSuite
{
    public class DBTest
    {
		private static AccountContext _accountContext;

		static DBTest() 
		{
			IConfiguration config = new ConfigurationBuilder().Build();

            string connectionString = "connectionString";

			DbContextOptions<AccountContext> DbContextOptions = 
				new DbContextOptionsBuilder<AccountContext>()
					.UseSqlServer(connectionString)
					.Options;

			_accountContext = new AccountContext(DbContextOptions);
		}

		[Fact]
		public void DatabaseIsSqlServer() 
		{
			Assert.True(_accountContext.Database.IsSqlServer());
		}
    }
}
