using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace World.Models

{
  public class City
  {
    public string Name {get; set;}
    public int Population {get; set;}
    public int Id {get; set;}
    // public static List<City> allCities {get; set;} =new List<City> {};

    public City(string name, int population, int id)
    {
      Name = name;
      Population = population;
      Id = id;
    }
    public static List<City> GetAll()
    {
      List<City> allCities = new List<City> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM city;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int cityId = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        int population = rdr.GetInt32(4);
        City newCity = new City(name, population, cityId);
        allCities.Add(newCity);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCities;
    }
  }
  // public class Country
  // {
  //   public string Name {get; set;}
  //   public string Continent {get; set;}
  //   public string HeadOfState {get; set;}
  //   public int Id {get; set;}
  //
  //   public City(string name, string continent, string headOfState, int id)
  //   {
  //     Name = name;
  //     Continent = continent;
  //     HeadOfState = headOfState;
  //     Id = id;
  //   }
  // }
}
