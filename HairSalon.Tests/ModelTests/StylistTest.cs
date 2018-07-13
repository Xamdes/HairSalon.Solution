using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTest : IDisposable
  {
    public void Dispose()
    {

    }
    [ClassInitialize]
    public static void StylistTests(TestContext ts)
    {
      DBConfiguration.UsingTestConnection();
    }
    [ClassCleanup]
    public static void Cleanup()
    {
      Stylist.DeleteAll();
    }
    [TestMethod]
    public void Return_True()
    {
      //Eventual Tests
      Assert.AreEqual(true, Stylist.ReturnTrue());
    }

    [TestMethod]
    public void ReturnStylistFromSql_True()
    {
      //Arrange
      Stylist newStylist = new Stylist("Sam");

      //Act
      newStylist.Save();
      Stylist secondStylist = Stylist.Find(newStylist.GetId());

      //Assert
      Assert.AreEqual(newStylist, secondStylist);
    }

    [TestMethod]
    public void Stylist_Not_Equal()
    {
      //Arrange
      Stylist firstStylist = new Stylist("Sam");
      Stylist secondStylist = new Stylist("Sam");

      //Act
      firstStylist.Save();
      secondStylist.Save();

      //Assert
      Assert.AreNotEqual(firstStylist, secondStylist);
    }

  }
}
