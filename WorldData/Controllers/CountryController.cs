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

    [HttpGet("Country/Form")]
    public ActionResult Form()
    {
      return View();
    }

    [HttpPost("Country/Create")]
    public ActionResult Create()
    {
      string code = Request.Form["code"]; 
      string name = Request.Form["name"];
      string continent = Request.Form["continent"];
      int population = Int32.Parse(Request.Form["population"]);

      Country myCountry = new Country(code, name, continent, population, 0);
      myCountry.Save();
      return View("Info", myCountry);

    }
  }
}
