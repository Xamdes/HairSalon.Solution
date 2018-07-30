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
    public void Found_Client_From_Stylist()
    {
      //Arrange
      Stylist firstStylist = new Stylist("Sam");

      //Act
      firstStylist.Save();
      firstStylist.AddClient("Jerry");
      List<Client> clients = firstStylist.GetClients();


      //Assert
      Assert.AreEqual("Jerry", clients[0].GetName());
    }

  }
}
