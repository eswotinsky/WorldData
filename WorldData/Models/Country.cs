using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace WorldDataProject.Models
{
  public class Country
  {
    private int _id;
    private string _name;
    private string _continent;
    private int _population;

    private static List<Country> _countries = new List<Country>();

    public Country(string name, string continent, int population, int index)
    {
      _name = name;
      _continent = continent;
      _population = population;
      _id = index;
    }

    public string GetName()
    {
      return _name;
    }

    public string GetContinent()
    {
      return _continent;
    }

    public int GetPopulation()
    {
      return _population;
    }

    public int GetId()
    {
      return _id;
    }

    public static Country Find(int id)
    {
      return _countries[id];
    }

    public static List<Country> GetAllCountries()
    {
      List<Country> allCountries = new List<Country>(){};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        string name = rdr.GetString(1);
        string continent = rdr.GetString(2);
        int population = rdr.GetInt32(6);
        allCountries.Add(new Country(name, continent, population, allCountries.Count));
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      _countries.Clear();
      Console.WriteLine(_countries.Count);
      _countries = allCountries;
      Console.WriteLine(_countries.Count);
      return allCountries;
    }

    public static List<Country> Find(string cont, int popMin, int popMax)
    {
      List<Country> allCountries = new List<Country>(){};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country WHERE continent='" + cont + "' AND population BETWEEN " + popMin + " AND " + popMax + ";";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        string name = rdr.GetString(1);
        string continent = rdr.GetString(2);
        int population = rdr.GetInt32(6);
        allCountries.Add(new Country(name, continent, population, allCountries.Count));
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      _countries = allCountries;
      return allCountries;
    }
    //
    // public static List<Country> FindPopulation(int popMin, int popMax)
    // {
    //   List<Country> allCountries = new List<Country>(){};
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"SELECT * FROM country WHERE population BETWEEN " + popMin + " AND " + popMax + ";";
    //   MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
    //   while (rdr.Read())
    //   {
    //     string name = rdr.GetString(1);
    //     string continent = rdr.GetString(2);
    //     int population = rdr.GetInt32(6);
    //     allCountries.Add(new Country(name, continent, population, allCountries.Count));
    //   }
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //   return allCountries;
    // }
  }
}
