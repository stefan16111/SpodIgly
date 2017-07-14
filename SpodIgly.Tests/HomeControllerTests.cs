using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpodIgly.Controllers;
using System.Web.Mvc;
using SpodIgly.ViewModels;
using System.Linq;
using System.Collections.Generic;
using SpodIgly.Models;
using Moq;
using System.Data.Entity;
using SpodIgly.DAL;
using SpodIgly.Infrastructure;

namespace SpodIgly.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void IndexAction_Returns3BestsellerAnd3NewItems()
        {
            //Arange
            var data = new List<Album>
            {
                new Album { IsBestseller = true, IsHidden = false},
                new Album { IsBestseller = true, IsHidden = false},
                new Album { IsBestseller = true, IsHidden = false},
                new Album { IsBestseller = false, IsHidden = false},
                new Album { IsBestseller = false, IsHidden = false},
                new Album { IsBestseller = true, IsHidden = true}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Album>>();
            mockSet.As<IQueryable<Album>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Album>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Album>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Album>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<StoreContext>();
            mockContext.Setup(c => c.Albums).Returns(mockSet.Object);

            var mockCache = new Mock<ICacheProvider>();

            var controller = new HomeController(mockContext.Object, mockCache.Object);

            //Act
            var result = controller.Index() as ViewResult;

            //Asset
            var viewModel = result.ViewData.Model as HomeViewModel;
            Assert.IsTrue(viewModel.Bestsellers.Count() == 3);
            Assert.IsTrue(viewModel.NewArrivals.Count() == 3);

        }

        [TestMethod]
        public void StaticContentAction_WithViewNamePassed_ReturnsViewTheSameName()
        {
            //Arage
            var mockContext = new Mock<StoreContext>();

            var mockCache = new Mock<ICacheProvider>();

            var controller = new HomeController(mockContext.Object, mockCache.Object);


            //Act
            var result = controller.StaticContent("TestView") as ViewResult;

            //asset
            Assert.AreEqual("TestView", result.ViewName);
        }
    }
}
