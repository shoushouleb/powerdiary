using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HasanShouman;
using HasanShouman.Controllers;
using System.Web.Hosting;
using System.IO;
using HasanShouman.Models.Classes;

namespace HasanShouman.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(null);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void LoadData()
        {
            string expected = "{\"Data\":[{\"CountSender\":null,\"CountReceiver\":null,\"Children\":[{\"CountSender\":\"2\",\"CountReceiver\":\"2\",\"Children\":null,\"ID\":null,\"EventDate\":\"2021-05-25T17:00:00\",\"EventType\":\"e\",\"Description\":null}],\"ID\":null,\"EventDate\":\"2021-05-25T17:00:00\",\"EventType\":null,\"Description\":null},{\"CountSender\":null,\"CountReceiver\":null,\"Children\":[{\"CountSender\":\"1\",\"CountReceiver\":\"1\",\"Children\":null,\"ID\":null,\"EventDate\":\"2021-05-25T18:00:00\",\"EventType\":\"c\",\"Description\":null},{\"CountSender\":\"4\",\"CountReceiver\":\"2\",\"Children\":null,\"ID\":null,\"EventDate\":\"2021-05-25T18:00:00\",\"EventType\":\"h\",\"Description\":null}],\"ID\":null,\"EventDate\":\"2021-05-25T18:00:00\",\"EventType\":null,\"Description\":null},{\"CountSender\":null,\"CountReceiver\":null,\"Children\":[{\"CountSender\":\"2\",\"CountReceiver\":\"2\",\"Children\":null,\"ID\":null,\"EventDate\":\"2021-05-25T19:00:00\",\"EventType\":\"l\",\"Description\":null},{\"CountSender\":\"1\",\"CountReceiver\":\"1\",\"Children\":null,\"ID\":null,\"EventDate\":\"2021-05-25T19:00:00\",\"EventType\":\"c\",\"Description\":null}],\"ID\":null,\"EventDate\":\"2021-05-25T19:00:00\",\"EventType\":null,\"Description\":null},{\"CountSender\":null,\"CountReceiver\":null,\"Children\":[{\"CountSender\":\"2\",\"CountReceiver\":\"2\",\"Children\":null,\"ID\":null,\"EventDate\":\"2021-05-25T20:00:00\",\"EventType\":\"h\",\"Description\":null}],\"ID\":null,\"EventDate\":\"2021-05-25T20:00:00\",\"EventType\":null,\"Description\":null},{\"CountSender\":null,\"CountReceiver\":null,\"Children\":[{\"CountSender\":\"1\",\"CountReceiver\":\"1\",\"Children\":null,\"ID\":null,\"EventDate\":\"2021-05-25T21:00:00\",\"EventType\":\"h\",\"Description\":null}],\"ID\":null,\"EventDate\":\"2021-05-25T21:00:00\",\"EventType\":null,\"Description\":null},{\"CountSender\":null,\"CountReceiver\":null,\"Children\":[{\"CountSender\":\"1\",\"CountReceiver\":\"1\",\"Children\":null,\"ID\":null,\"EventDate\":\"2021-05-25T22:00:00\",\"EventType\":\"h\",\"Description\":null}],\"ID\":null,\"EventDate\":\"2021-05-25T22:00:00\",\"EventType\":null,\"Description\":null}],\"Key\":\"Success\",\"Message\":\"Done\"}";
            // Arrange
            IPathProvider fakePathProvider = new FakePathProvider();

            HomeController controller = new HomeController(fakePathProvider);
            // Act
            string result = controller.LoadData("h");

            // Assert
           Assert.AreEqual(expected,result);
        }

 
    }
}
