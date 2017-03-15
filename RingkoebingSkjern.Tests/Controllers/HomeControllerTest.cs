using Moq;
using NUnit.Framework;
using RingkoebingSkjern.Controllers;
using RingkoebingSkjern.Models;
using System.Web.Mvc;
using Login = RingkoebingSkjern.Models.Login;

namespace RingkoebingSkjern.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [Test]
        public void Get_Login_From_Database()
        {
            var expected = new Login {Brugernavn = "Frants", Adgangskode = "123"};
            var loginRepositoryMock = new Mock<ILoginRepository>();
            loginRepositoryMock
                .Setup(gl => gl.GetLogin("Frants"))
                .Returns(expected);
            var loginService = new LoginService(loginRepositoryMock.Object);
            var actual = loginService.GetLogin(expected.Brugernavn);

            Assert.AreEqual(expected.Brugernavn, actual.Brugernavn);
            Assert.AreEqual(expected.Adgangskode, actual.Adgangskode);
        }
    }
}
