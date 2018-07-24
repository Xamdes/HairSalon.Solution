using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {

    [HttpGet("/stylists")]
    public ActionResult Index()
    {
      List<Stylist> allStylists = Stylist.GetAll();
      return View(allStylists);
    }

    [HttpPost("/stylists")]
    public ActionResult Create(string name)
    {
      Stylist newStylist = new Stylist (name);
      newStylist.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/stylists/new")]
    public ActionResult CreateForm()
    {
      return View();
    }

    [HttpGet("/stylists/{id}")]
    public ActionResult Details(int id)
    {
      Stylist newStylist = Stylist.Find(id);
      return View(newStylist);
    }

    [HttpPost("/stylists/{id}/save")]
    public ActionResult NewClientRedirect(int id, string name)
    {
      Stylist newStylist = Stylist.Find(id);
      newStylist.AddClient(name);
      //return View(newStylist.GetId());
      return RedirectToAction("Details",id);
    }

    [HttpGet("/stylists/{id}/new")]
    public ActionResult AddClient(int id)
    {
      return View(id);
    }

    [HttpGet("/stylists/{id}/delete")]
    public ActionResult Delete(int id)
    {
        Stylist.DeleteId(id);
        return RedirectToAction("Index");
    }

    [HttpPost("/stylists/delete")]
    public ActionResult DeleteAll()
    {
      Stylist.DeleteAll(true);
      return View();
    }

    [HttpGet("/stylists/{id}/newname")]
    public ActionResult ChangeName(int id)
    {
        return View(Stylist.Find(id));
    }

    [HttpPost("/stylists/{id}/newname")]
    public ActionResult ReturnChangeName(int id, string newName)
    {
        Stylist.Find(id).ChangeName(newName);
        return RedirectToAction("Details",id);
    }
  }

}
