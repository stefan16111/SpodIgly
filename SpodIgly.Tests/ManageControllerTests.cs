using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SpodIgly.App_Start;
using SpodIgly.Controllers;
using SpodIgly.DAL;
using SpodIgly.Infrastructure;
using SpodIgly.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SpodIgly.Tests
{
    [TestClass]
    public class ManageControllerTests
    {
        [TestMethod]
        public async Task ChangePassword_WithModelErrors_RedirectsToIndex()
        {
            //Arrage
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new ApplicationUserManager(userStore.Object);
            var controller = new ManageController(userManager);
            var vn = new ChangePasswordViewModel();
            controller.ModelState.AddModelError("key", "error");

            //Act
            var result = (RedirectToRouteResult)await controller.ChangePassword(vn);

            //Assert
            Assert.AreEqual("Index", result.RouteValues["Action"]);
        }

        [TestMethod]
        public void ChangeOrderState_OrderStateChangesToShipped_SendConfirmationEmail()
        {
            //Arrage
            var mockSet = new Mock<DbSet<Order>>();
            Order orderToModify = new Order { OrderId = 1, OrderState = OrderState.New };
            mockSet.Setup(m => m.Find(It.IsAny<int>())).Returns(orderToModify);

            var mockContext = new Mock<StoreContext>();
            mockContext.Setup(c => c.Orders).Returns(mockSet.Object);

            //Mock MailService
            var mailMock = new Mock<IMailService>();

            Order orderArgument = new Order { OrderId = 1, OrderState = OrderState.Shipped };

            var controller = new ManageController(mockContext.Object, mailMock.Object);

            //Act
            var result = controller.ChangeOrderState(orderArgument);

            //Assert
            mailMock.Verify(m => m.SendOrderShippedEmail(It.IsAny<Order>()), Times.Once());
        }
    }
}
