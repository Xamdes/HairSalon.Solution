using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Specialty
  {
    private static string _tableName = "specialty";
    private string _specialty;
    private int _id;

    public string GetSpecialty()
    {
      return _specialty;
    }

    public void SetSpecialty(string s)
    {
      _specialty = s;
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
      string columns = "name";
      List<string> valueNames = new List<string>(){"@Name"};
      List<Object> values = new List<Object>(){_name};
      DB.SaveToTable(_tableName,columns,valueNames,values);
      _id = DB.LastInsertId(_tableName);
    }

    public void AddClient(Client newClient)
    {
      //Needs to update client
      newClient.SetStylist(_id);
      newClient.Save();
    }

    public void AddClient(string name)
    {
      Client newClient = new Client(name,_id);
      newClient.Save();
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
        Stylist newStylist = new Stylist(name,id);
        stylists.Add(newStylist);
      }
      DB.CloseConnection();
      return stylists;
    }

    public List<Client> GetClients(string orderBy = "id", string order = "ASC")
    {
      List<Client> clients = new List<Client>(){};
      DB.OpenConnection();
      DB.SetCommand(@"SELECT * FROM clients WHERE stylistId=@Id  ORDER BY "+orderBy+" "+order+";");
      DB.AddParameter("@Id",_id);
      MySqlDataReader rdr = DB.ReadSqlCommand();
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(2);
        Client newClient = new Client(name,_id,id);
        clients.Add(newClient);
      }
      DB.CloseConnection();
      return clients;
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
      return (new Stylist(name,stylistId));
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
      if (otherItem is Stylist)
      {
        Stylist newItem = (Stylist) otherItem;
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