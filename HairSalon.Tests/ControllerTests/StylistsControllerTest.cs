using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistsControllerTest
  {

    [TestMethod]
    public void Index_ReturnsCorrectView_True()
    {
      //Arrange
      StylistsController controller = new StylistsController();

      //Act
      ActionResult indexView = controller.Index();

      //Assert
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }
  }
}
