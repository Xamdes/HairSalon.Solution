using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class SpecialtiesController : Controller
  {
    [HttpGet("/specialties")]
    public ActionResult Index()
    {
      return View(Specialty.GetAll());
    }

    [HttpGet("/specialties/add")]
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost("/specialties")]
    public ActionResult CreateSpecialtiy(string name)
    {
      Specialty newSpecialty = new Specialty(name);
      newSpecialty.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/specialties/{specialtyId}")]
    public ActionResult Details(int specialtyId)
    {
      Specialty newClient = Specialty.Find(specialtyId);
      return View(newClient);
    }

    [HttpGet("/specialties/{specialtyId}/delete")]
    public ActionResult Delete(int specialtyId)
    {
      Specialty.DeleteId(specialtyId);
      return RedirectToAction("Index");
    }

    [HttpPost("/specialties/delete")]
    public ActionResult DeleteAll()
    {
      Specialty.DeleteAll();
      return RedirectToAction("Index");
    }
  }
}
