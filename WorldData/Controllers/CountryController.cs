using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorldDataProject.Models;

namespace WorldDataProject.Controllers
{
  public class CountryController : Controller
  {
    [HttpGet("Country/Info/{id}")]
    public ActionResult Info(int id)
    {
      Country myCountry = Country.Find(id);
      return View(myCountry);
    }

    [HttpPost("Country/Find")]
    public ActionResult Find()
    {
      List<Country> countries = new List<Country>();

      string cont = Request.Form["continent"];
      int popMin = Int32.Parse(Request.Form["pop-min"]);
      int popMax = Int32.Parse(Request.Form["pop-max"]);

      countries = Country.Find(cont, popMin, popMax);

      return View("../Home/Index", countries);
    }
  }
}
