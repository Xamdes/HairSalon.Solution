using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtyTest : IDisposable
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
      Specialty.DeleteAll();
    }
    [TestMethod]
    public void Return_True()
    {
      //Eventual Tests
      Assert.AreEqual(true, Specialty.ReturnTrue());
    }

    [TestMethod]
    public void ReturnStylistFromSql_True()
    {
      //Arrange
      Specialty newStylist = new Specialty("Sam");

      //Act
      newStylist.Save();
      Specialty secondStylist = Specialty.Find(newStylist.GetId());

      //Assert
      Assert.AreEqual(newStylist, secondStylist);
    }

    [TestMethod]
    public void Stylist_Not_Equal()
    {
      //Arrange
      Specialty firstStylist = new Specialty("Sam");
      Specialty secondStylist = new Specialty("Sam");

      //Act
      firstStylist.Save();
      secondStylist.Save();

      //Assert
      Assert.AreNotEqual(firstStylist, secondStylist);
    }

  }
}
