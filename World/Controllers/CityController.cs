
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using World.Models;
using System;

namespace World.Controllers
{
  public class CityController : Controller
  {
    [HttpGet("/city")]
    public ActionResult Index()
    {

      List<City> citiesList = City.GetAll();
      return View(citiesList);
    }

    [HttpGet("/city/new")]
    public ActionResult New()
    {
      return View();
    }
  }
}
