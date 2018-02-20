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
    private string _code;

    private static List<Country> _countries = new List<Country>();

    public Country(string code, string name, string continent, int population, int index)
    {
      _name = name;
      _continent = continent;
      _population = population;
      _id = index;
      _code = code;
    }

    public string GetCode()
    {
      return _code;
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
        string code = rdr.GetString(0);
        string name = rdr.GetString(1);
        string continent = rdr.GetString(2);
        int population = rdr.GetInt32(6);
        allCountries.Add(new Country(code, name, continent, population, allCountries.Count));
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      _countries.Clear();
      _countries = allCountries;
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
        string code = rdr.GetString(0);
        string name = rdr.GetString(1);
        string continent = rdr.GetString(2);
        int population = rdr.GetInt32(6);
        allCountries.Add(new Country(code, name, continent, population, allCountries.Count));
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      _countries = allCountries;
      return allCountries;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO country (code, name, continent, population) VALUES (@code, @name, @continent, @population);";

      MySqlParameter code = new MySqlParameter();
      code.ParameterName = "@code";
      code.Value = this._code;
      cmd.Parameters.Add(code);

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@name";
      name.Value = this._name;
      cmd.Parameters.Add(name);

      MySqlParameter continent = new MySqlParameter();
      continent.ParameterName = "@continent";
      continent.Value = this._continent;
      cmd.Parameters.Add(continent);

      MySqlParameter population = new MySqlParameter();
      population.ParameterName = "@population";
      population.Value = this._population;
      cmd.Parameters.Add(population);

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

    }
  }
}
