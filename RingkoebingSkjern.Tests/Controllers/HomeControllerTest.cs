using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RingkoebingSkjern.Controllers;
using RingkoebingSkjern.Models;
using System.Web.Mvc;
using Login = RingkoebingSkjern.Models.Login;


namespace RingkoebingSkjern.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index() //Check om Index metode i HomeController returnerer korrekt View
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        /*[TestMethod]
        public void Get_Login_From_Database()
        {
            var expected = new Login {Brugernavn = "Frants", Adgangskode = "123"};
            Mock<ILoginRepository> loginRepositoryMock = new Mock<ILoginRepository>(); //Opret mock af ILoginRepository
            loginRepositoryMock
                .Setup(gl => gl.GetLogin("Frants"))
                .Returns(expected); //Hver gang GetLogin() kaldes returneres 'expected' objektet
            var loginService = new LoginService(loginRepositoryMock.Object); //Objekt under test
            var actual = loginService.GetLogin(expected.Brugernavn); //Vil returnere 'expected'

            Assert.AreEqual(expected.Brugernavn, actual.Brugernavn);
           // Assert.AreEqual(expected.Adgangskode, actual.Adgangskode);
        }*/
        /*[TestMethod]
        public void TestInsert()
        {
            //Arrange
            var commandMock = new Mock<IDbCommand>();
            commandMock
                .Setup(m => m.ExecuteNonQuery()) //verificér at en command bliver eksekveret
                .Verifiable();

            var connectionMock = new Mock<IDbConnection>(); //verificér at en command bliver oprettet
            connectionMock
                .Setup(m => m.CreateCommand())
                .Returns(commandMock.Object);

            var connectionFactoryMock = new Mock<IDbConnectionFactory>(); //verificér at der kan oprettes forbindelse
            connectionFactoryMock
                .Setup(m => m.CreateConnection())
                .Returns(connectionMock.Object);

            var sut = new MyDataAccessClass(connectionFactoryMock.Object);
            var brugernavn = "Frants";
            var adgangskode = "123";

            //Act
            sut.Insert(brugernavn, adgangskode);

            //Assert
            commandMock.Verify();
        }*/
    }
}
