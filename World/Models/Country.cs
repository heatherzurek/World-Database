using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace World.Models

{
  public class Country
  {
    public string Name {get; set;}
    public string Continent {get; set;}
    public string HeadOfState {get; set;}
    public static List<Country> allCountry {get; set;} =new List<Country> {};
    // public char CountryCode {get; set;}

    public Country(string name, string continent, string headOfState)
    {
      Name = name;
      Continent = continent;
      HeadOfState = headOfState;
    }

    public static List<Country> GetAll()
    {
      // List<Country> allCountries = new List<Country> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        // char countryCode = rdr.GetChar(0);
        string name = rdr.GetString(1);
        string continent = rdr.GetString(2);
        string headOfState = "Lindsey";
        if(!rdr.IsDBNull(12))
        {
          headOfState = rdr.GetString(12);
        }
        Country newCountry = new Country(name, continent, headOfState);
        allCountry.Add(newCountry);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCountry;
    }
    public static List<Country> GetContinent(string userContinent)
    {
      Console.WriteLine(userContinent);

      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country WHERE Continent = '"+ userContinent+"';";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        // char countryCode = rdr.GetChar(0);
        string name = rdr.GetString(1);
        string continent = rdr.GetString(2);
        string headOfState = "Lindsey";
        if(!rdr.IsDBNull(12))
        {
          headOfState = rdr.GetString(12);
        }
        Country newCountry = new Country(name, continent, headOfState);
        allCountry.Add(newCountry);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCountry;
    }

    // public static void ClearAll()
    // {
    //   allCountry.Clear();
    // }

  }
}
