using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorldDataProject.Models;

namespace WorldDataProject.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      List<Country> countries = Country.GetAllCountries();
      return View(countries); 
    }
  }
}
