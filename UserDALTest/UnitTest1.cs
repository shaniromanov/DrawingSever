using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OracleDAL;
using UserDAL;

namespace UserDALTest
{
    public class Tests
    {
        IConfiguration _configuration;
        [SetUp]
        public void Setup()
        {
            _configuration = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json")
              .Build();
        }

        [Test]
        public void GetUserExists()
        {
            var dal = new UserDALImpl(new InfraDAL(), _configuration);
            var result = dal.GetUser("shaniromanov@gmail.com");
            Assert.IsTrue(result.Tables[0].Rows.Count>0);
        }
        [Test]
        public void GetUserNotExists()
        {
            var dal = new UserDALImpl(new InfraDAL(), _configuration);
            var result = dal.GetUser("1111@gmail.com");
            Assert.AreEqual(0, result.Tables[0].Rows.Count);
        }
        [Test]
        public void CreateUser()
        {
            var dal = new UserDALImpl(new InfraDAL(), _configuration);
            var result = dal.CreateUser("1122@gmail.com", "1122");
            result = dal.GetUser("1122@gmail.com");
            Assert.IsTrue(result.Tables[0].Rows.Count > 0);
        }

        [Test]
        public void RemoveUser()
        {
            var dal = new UserDALImpl(new InfraDAL(), _configuration);
            var result = dal.RemoveUser("1122@gmail.com");
            result = dal.GetUser("1122@gmail.com");
            Assert.AreEqual(0, result.Tables[0].Rows.Count);
        }

    }
}