using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtiesControllerTest
  {

    [TestMethod]
    public void Index_ReturnsCorrectView_True()
    {
      //Arrange
      SpecialtiesController controller = new SpecialtiesController();

      //Act
      ActionResult indexView = controller.Index();

      //Assert
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }
  }
}
