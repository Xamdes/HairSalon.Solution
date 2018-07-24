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

    public int GetStylistId()
    {
      return _stylistId;
    }

    public string GetStylistName()
    {
    return Stylist.Find(_stylistId).GetName();
    }

    public void SetStylist(int stylistId)
    {
      _stylistId = stylistId;
    }

    public void Save()
    {
      string columns = "name,stylistId";
      List<string> valueNames = new List<string>(){"@Name","@StylistId"};
      List<Object> values = new List<Object>(){_name,_stylistId};
      DB.OpenConnection();
      DB.SaveToTable(_tableName,columns,valueNames,values);
      _id = DB.LastInsertId();
      DB.CloseConnection();
    }

    public static Client Find(int id)
    {
      int clientId = -1;
      string name = "";
      int stylistId = -1;
      DB.OpenConnection();
      DB.SetCommand(@"SELECT * FROM clients WHERE id=@thisId;");
      DB.AddParameter("@thisId",id);
      MySqlDataReader rdr = DB.ReadSqlCommand();
      while(rdr.Read())
      {
        clientId = rdr.GetInt32(0);
        stylistId = rdr.GetInt32(1);
        name = rdr.GetString(2);
      }
      DB.CloseConnection();
      return (new Client(name,stylistId,clientId));
    }

    public static List<Client> GetAll()
    {
    string orderBy = "id"; string order = "ASC";
    List<Object> objects = new List<Object>(){};
    DB.OpenConnection();
    DB.SetCommand(@"SELECT * FROM "+_tableName+" ORDER BY "+orderBy+" "+order+";");
    DB.ReadTable(DelegateGetAll,objects);
    DB.CloseConnection();
    return objects.Cast<Client>().ToList();
    }

    public static void DelegateGetAll(MySqlDataReader rdr, List<Object> objects)
    {
       int clientId = rdr.GetInt32(0);
       int stylistId = rdr.GetInt32(1);
       string name = rdr.GetString(2);
       Client newStylist = new Client(name,stylistId,clientId);
       objects.Add(newStylist);
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

    public static bool ReturnTrue()
    {
      return true;
    }

    public override bool Equals(System.Object otherItem)
    {
      if (otherItem is Client)
      {
        Client newItem = (Client) otherItem;
        return this.GetId().Equals(newItem.GetId());
      }
      else
      {
        return false;
      }
    }

    public override int GetHashCode()
    {
      return this.GetName().GetHashCode();
    }

  }
}
