using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace WebApplication1.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        private AccountsController _controller;

        //Como controller es una clase comun se utiliza aqui, para no tener codigo repetido en cada test
        [TestInitialize]
        public void SetupController()
        {
            //It's like a contructor.
            _controller = new AccountsController();
        }

        [TestMethod]
        public void Create_NewAccount_ShouldBeSuccessfull()
        {
            // Arrange
            var expectedAccount = new Account()
            {
                AccNumber = "01",
                Name = "Activos",
                AccFatherNumber = "",
                Total = 100
            };

            // Act
            // put attention on as RedirectToRouteResult the reason of no ViewResult is because we don't return nothing insted of that we redirect to index 
            var result = _controller.Create(expectedAccount) as RedirectToRouteResult;          

            // Assert
            // if we successfull create a record we send to index, so thats the reason why we should see if we are in the correct action
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Create_NewAccount_ShouldBeWrong()
        {
            // Arrange
            var expectedAccount = new Account()
            {
                //AccNumber = "01",
                AccFatherNumber = "",
                Name = "test",
                Total = 100
            };

            // Act
            // in this case we use ViewResult because we return the bad object
            var result = _controller.Create(expectedAccount) as ViewResult;
            var data = (Account)result.Model;
            
            // the correct way to handle this is having success = false and a message with information
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(null, data.AccNumber);
        }
    }
}
