using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace WorldDataProject.Models
{
  public class City
  {
    private string _name;
    private string _countryCode;
    private int _population;
    private int _id;


    public City(string name, string countryCode, int population, int id)
    {
      _name = name;
      _countryCode = countryCode;
      _population = population;
      _id = id;
    }

    public string GetName()
    {
      return _name;
    }

    public string GetCountryCode()
    {
      return _countryCode;
    }

    public int GetPopulation()
    {
      return _population;
    }

    public int GetId()
    {
      return _id;
    }

    public static List<City> GetAllCities()
    {
      List<City> allCities = new List<City>(){};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM city;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        string name = rdr.GetString(1);
        string countryCode = rdr.GetString(2);
        int population = rdr.GetInt32(4);
        int id = rdr.GetInt32(0);
        allCities.Add(new City(name, countryCode, population, id));
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCities;
    }

    public static City Find(int id)
    {
      string name = "";
      string countryCode = "";
      int population = 0;
      int index = 0;

      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM city Where id=" + id + ";";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        name = rdr.GetString(1);
        countryCode = rdr.GetString(2);
        population = rdr.GetInt32(4);
        index = rdr.GetInt32(0);
      }
      City myCity = new City(name, countryCode, population, index);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return myCity;
    }


  }
}
