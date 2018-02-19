using System;
using MySql.Data.MySqlClient;
using WorldDataProject;

namespace WorldDataProject.Models
{
  public class DB
  {
    public static MySqlConnection Connection()
    {
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      return conn;
    }
  }
}
