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
  }
}
