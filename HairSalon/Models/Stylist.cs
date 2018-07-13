using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Stylist
  {
    private static string tableName = _stylists;
    private string _name;
    private int _id;
    private List<Client> _clients;

    public Stylist(string name,int id = -1)
    {
      _name = name;
      _id = id;
      _clients = new List<Client>(){};
    }

    public string GetName()
    {
      return _name;
    }

    public int GetId()
    {
      return _id;
    }

    public void Save()
    {
      string columns = "id,name";
      List<string> valueNames = new List<string>(){"@Id","@Name"};
      List<Object> values = new List<Object>(){_id,_name};
      DB.SaveToTable(_tableName,columns,valueNames,values);
      _id = DB.LastInsertId(_tableName);
    }

    public static List<Stylist> GetAll(string orderBy = "id", string order = "ASC")
    {
      List<Stylist> stylists = new List<Stylist>(){};
      DB.OpenConnection();
      DB.SetCommand(@"SELECT * FROM stylists ORDER BY "+orderBy+" "+order+";");
      MySqlDataReader rdr = DB.ReadSqlCommand();
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        Stylist newStylist = new Stylist(id,name);
        stylists.Add(newStylist);
      }
      DB.CloseConnection();
      return stylists;
    }

    public static Stylist Find(int id)
    {
      int stylistId = -1;
      string name = "";
      DB.OpenConnection();
      DB.SetCommand(@"SELECT * FROM stylists WHERE id=@thisId;");
      DB.AddParameter("@thisId",id);
      MySqlDataReader rdr = DB.ReadSqlCommand();
      while(rdr.Read())
      {
        stylistId = rdr.GetInt32(0);
        name = rdr.GetString(1);
      }
      DB.CloseConnection();
      return (new Stylist(stylistId,name));
    }

    public static void DeleteAll(bool saveUniqueIds = true)
    {
      DB.ClearTable(_tableName,saveUniqueIds);
    }

    public static void DeleteId(int deleteId)
    {
      DB.DeleteById(_tableName,deleteId);
    }

    public void Delete()
    {
      DB.DeleteById(_tableName,_id);
    }

  }
}
