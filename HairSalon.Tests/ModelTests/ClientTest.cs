using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest : IDisposable
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
      Client.DeleteAll();
    }
    [TestMethod]
    public void Return_True()
    {
      //Eventual Tests
      Assert.AreEqual(true, Client.ReturnTrue());
    }

    [TestMethod]
    public void ReturnStylistFromSql_True()
    {
      //Arrange
      Client firstClient = new Client("Jerry",0,1);

      //Act
      firstClient.Save();
      Client sameClient = Client.Find(firstClient.GetId());

      //Assert
      Assert.AreEqual(firstClient, sameClient);
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
