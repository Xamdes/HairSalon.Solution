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
  }
}
