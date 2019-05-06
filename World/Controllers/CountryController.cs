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

    [HttpPost("/country/sort")]
    public ActionResult Create(string continent)
    {
      List<Country> countriesShortenedList = Country.GetContinent(continent);
      return View("Show", countriesShortenedList);
    }

    [HttpGet("/country/sorted")]
    public ActionResult Show()
    {
      return View();
    }
  }
}
