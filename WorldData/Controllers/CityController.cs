using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorldDataProject.Models;

namespace WorldDataProject.Controllers
{
  public class CityController : Controller
  {
    [HttpGet("City/Display")]
    public ActionResult Display()
    {
      List<City> allCities = City.GetAllCities();
      return View(allCities);
    }

    [HttpGet("City/Info/{id}")]
    public ActionResult Info(int id)
    {
      City myCity = City.Find(id);
      return View(myCity);
    }
  }
}
