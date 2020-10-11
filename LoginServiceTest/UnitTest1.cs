using DrawingContracts.DTO;
using LoginService;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OracleDAL;
using System.Threading.Tasks;
using UserDAL;

namespace LoginServiceTest
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
        public void LoginOkTest()
        {
            var loginService = new LoginServiceImpl(new UserDALImpl(new InfraDAL(), _configuration));
            LoginRequest request = new LoginRequest();
            request.EmailAddress = "shaniromanov@gmail.com";
            var response = loginService.Login(request);
            Assert.IsInstanceOf(typeof(LoginResponseOK ), response);
        }
        [Test]
        public void LoginForRemovedUserTest()
        {
            var loginService = new LoginServiceImpl(new UserDALImpl(new InfraDAL(), _configuration));
            LoginRequest request = new LoginRequest();
            request.EmailAddress = "Ayala@gmail.com";
            var response = loginService.Login(request);
            Assert.IsInstanceOf(typeof(LoginResponseUserNotExists), response);
        }

        [Test]
        public void LoginForUserNotExists()
        {
            var loginService = new LoginServiceImpl(new UserDALImpl(new InfraDAL(), _configuration));
            LoginRequest request = new LoginRequest();
            request.EmailAddress = "111@gmail.com";
            var response = loginService.Login(request);
            Assert.IsInstanceOf(typeof(LoginResponseUserNotExists), response);
        }
    }
}