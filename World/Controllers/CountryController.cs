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

      List<Country> allCountry = Country.GetAll();
      return View(allCountry);
    }

    [HttpGet("/country/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/country")]
    public ActionResult Create(string userContinent)
    {
      List<Country> countriesShortenedList = Country.GetContinent(userContinent);
      return RedirectToAction("Index");
    }
  }
}
