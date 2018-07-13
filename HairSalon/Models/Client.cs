using System;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;


namespace HairSalon.Models
{
  public class Client
  {
    private static string _tableName = "clients";
    private string _name;
    private int _id;
    private int _stylistId;

    public Client(string name,int stylistId, int id = -1)
    {
      _name = name;
      _stylistId = stylistId;
      _id = id;
    }

    public string GetName()
    {
      return _name;
    }

    public void SetName(string name)
    {
      _name = name;
    }

    public int GetId()
    {
      return _id;
    }
    public void SetId(int id)
    {
      _id = id;
    }

    public int GetStylist()
    {
      return _stylistId;
    }
    public void SetStylist(int stylistId)
    {
      _stylistId = stylistId;
    }

    public void Save()
    {
      string columns = "name";
      List<string> valueNames = new List<string>(){"@Name"};
      List<Object> values = new List<Object>(){_name};
      DB.SaveToTable(_tableName,columns,valueNames,values);
      _id = DB.LastInsertId(_tableName);
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
