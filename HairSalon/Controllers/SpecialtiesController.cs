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
      Specialty newSpecialty = Specialty.Find(specialtyId);
      return View(newSpecialty);
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

    [HttpGet("/specialties/{specialtyId}/add-stylist")]
    public ActionResult AddStylist(int specialtyId)
    {
      return View(specialtyId);
    }

    [HttpPost("/specialties/{specialtyId}/add-stylist")]
    public ActionResult RedirectAddStylist(int specialtyId,int stylistId)
    {
      Specialty tempSpecialty = Specialty.Find(specialtyId);
      Stylist tempStylist = Stylist.Find(stylistId);
      tempSpecialty.AddStylist(tempStylist);
      return RedirectToAction("Details");
    }
  }
}
