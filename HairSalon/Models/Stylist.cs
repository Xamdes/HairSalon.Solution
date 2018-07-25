using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Stylist
  {
    private static string _tableName = "stylists";
    private static string _tableRelational = "stylists_specialties";
    private string _name;
    private int _id;

    public Stylist(string name,int id = -1)
    {
      _name = name;
      _id = id;
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
      DB.OpenConnection();
      DB.SaveToTable(_tableName,columns,valueNames,values);
      _id = DB.LastInsertId();
      DB.CloseConnection();
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

    public static List<Stylist> GetAll()
    {
    string orderBy = "id"; string order = "ASC";
    List<Object> objects = new List<Object>(){};
    DB.OpenConnection();
    DB.SetCommand(@"SELECT * FROM "+_tableName+" ORDER BY "+orderBy+" "+order+";");
    DB.ReadTable(DelegateGetAll,objects);
    DB.CloseConnection();
    return objects.Cast<Stylist>().ToList();
    }

    public static void DelegateGetAll(MySqlDataReader rdr, List<Object> objects)
    {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        Stylist newStylist = new Stylist(name,id);
        objects.Add(newStylist);
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

    public List<Specialty> GetSpecialties(string orderBy = "id", string order = "ASC")
    {
      List<Specialty> specialties = new List<Specialty>(){};
      DB.OpenConnection();
      DB.SetCommand(@"SELECT * FROM "+_tableRelational+" WHERE stylistId=@thisId ORDER BY "+orderBy+" "+order+";");
      DB.AddParameter("@thisId",_id);
      MySqlDataReader rdr = DB.ReadSqlCommand();
      while(rdr.Read())
      {
        Specialty newSpeciality = Specialty.Find(rdr.GetInt32(1));
        specialties.Add(newSpeciality);
      }
      DB.CloseConnection();
      return specialties;
    }

    public void AddSpecialty(Specialty newSpecialty)
    {
      string columns = "speciltyId,stylistId";
      List<string> valueNames = new List<string>(){"@SpecialtyId,@StylistId"};
      List<Object> values = new List<Object>(){newSpecialty.GetId(),_id};
      DB.OpenConnection();
      DB.SaveToTable(_tableName,columns,valueNames,values);
      DB.CloseConnection();
    }

    public void ChangeName(string newName)
    {
      DB.Edit(_tableName,_id, "name",  newName);
    }

    public static void DeleteAll(bool saveUniqueIds = true)
    {
      DB.ClearTable(_tableName,saveUniqueIds);
      DB.ClearTable(_tableRelational,saveUniqueIds);
    }

    public static void DeleteId(int deleteId)
    {
      DB.DeleteById(_tableName,deleteId);
      DB.DeleteBy(_tableRelational,"stylistId",deleteId);
    }

    public void Delete()
    {
      DB.DeleteById(_tableName,_id);
      DB.DeleteBy(_tableRelational,"stylistId",_id);
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
