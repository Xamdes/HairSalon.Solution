using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    [HttpGet("/clients")]
    public ActionResult Index()
    {
      return View(Client.GetAll());
    }

    [HttpGet("/clients/{clientId}")]
    public ActionResult Details(int clientId)
    {
      Client newClient = Client.Find(clientId);
      return View(newClient);
    }

    [HttpGet("/clients/{clientId}/delete")]
    public ActionResult Delete(int clientId)
    {
      Client.DeleteId(clientId);
      return RedirectToAction("Index");
    }

    [HttpPost("/clients/delete")]
    public ActionResult DeleteAll()
    {
      Client.DeleteAll();
      return RedirectToAction("Index");
    }

    [HttpGet("/clients/{clientId}/change-stylist")]
    public ActionResult ChangeStylist(int clientId)
    {
        return View(clientId);
    }

    [HttpPost("/clients/{clientId}/change-stylist")]
    public ActionResult ReturnChangeStylist(int clientId, int stylistId)
    {
        Client tempClient = Client.Find(clientId);
        tempClient.SetStylist(stylistId);
        tempClient.UpdateStylist();
        return RedirectToAction("Details",clientId);
    }

    [HttpGet("/clients/{clientId}/change-name")]
    public ActionResult ChangeName(int clientId)
    {
      Client newClient = Client.Find(clientId);
      return View(newClient);
    }

    [HttpPost("/clients/{clientId}/change-name")]
    public ActionResult ReturnChangeName(int clientId, string name)
    {
        Client tempClient = Client.Find(clientId);
        tempClient.SetName(name);
        tempClient.UpdateName();
        return RedirectToAction("Details",clientId);
    }
  }
}
