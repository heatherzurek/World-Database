using Microsoft.AspNetCore.Mvc;
using World.Models;
using System.Collections.Generic;
using System;

namespace World.Controllers
{
  public class CountryController : Controller
  {
    [HttpGet("/country")]
    public ActionResult Index()
    {

      List<Country> countriesList = Country.GetAll();
      return View(countriesList);
    }

    [HttpGet("/country/new")]
    public ActionResult New()
    {
      return View();
    }
  }
}
