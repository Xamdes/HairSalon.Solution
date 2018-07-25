using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Specialty
  {
    private static string _tableName = "specialties";
    private static string _tableRelational = "stylists_specialties";
    private string _specialty;
    private int _id;

    public Specialty(string s,int id = -1)
    {
      _specialty = s;
      _id = id;
    }

    public string GetSpecialty()
    {
      return _specialty;
    }

    public void SetSpecialty(string specialty,int id = 0)
    {
      _specialty = specialty;
      _id = id;
    }

    public int GetId()
    {
      return _id;
    }

    public void Save()
    {
      string columns = "name";
      List<string> valueNames = new List<string>(){"@Specialty"};
      List<Object> values = new List<Object>(){_specialty};
      DB.OpenConnection();
      DB.SaveToTable(_tableName,columns,valueNames,values);
      _id = DB.LastInsertId();
      DB.CloseConnection();
    }

    public void AddSpecialty(string s)
    {
      Specialty newSpecialty = new Specialty(s);
      newSpecialty.Save();
    }

    public static List<Stylist> GetStylists(int id, string orderBy = "id", string order = "ASC")
    {
      List<Stylist> stylists = new List<Stylist>(){};
      DB.OpenConnection();
      DB.SetCommand(@"SELECT * FROM "+_tableRelational+" WHERE specialtyId=@thisId ORDER BY "+orderBy+" "+order+";");
      DB.AddParameter("@thisId",id);
      MySqlDataReader rdr = DB.ReadSqlCommand();
      while(rdr.Read())
      {
        Stylist newStylist = Stylist.Find(rdr.GetInt32(2));
        stylists.Add(newStylist);
      }
      DB.CloseConnection();
      return stylists;
    }

    public void AddStylist(Stylist tempStylist)
    {
      DB.OpenConnection();
      DB.SetCommand(@"INSERT INTO "+_tableRelational+" (specialtyId,stylistId) VALUES (@SpecialtyId,@StylistId);");
      DB.AddParameter("@SpecialtyId",_id);
      DB.AddParameter("@StylistId",tempStylist.GetId());
      DB.RunSqlCommand();
      DB.CloseConnection();
    }

    public static List<Specialty> GetAll(string orderBy = "id", string order = "ASC")
    {
      List<Specialty> specialties = new List<Specialty>(){};
      DB.OpenConnection();
      DB.SetCommand(@"SELECT * FROM "+_tableName+" ORDER BY "+orderBy+" "+order+";");
      MySqlDataReader rdr = DB.ReadSqlCommand();
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string specialty = rdr.GetString(1);
        Specialty newSpeciality = new Specialty(specialty,id);
        specialties.Add(newSpeciality);
      }
      DB.CloseConnection();
      return specialties;
    }

    public static Specialty Find(int id)
    {
      int sid = -1;
      string specialty = "";
      DB.OpenConnection();
      DB.SetCommand(@"SELECT * FROM "+_tableName+" WHERE id=@thisId;");
      DB.AddParameter("@thisId",id);
      MySqlDataReader rdr = DB.ReadSqlCommand();
      while(rdr.Read())
      {
        sid = rdr.GetInt32(0);
        specialty = rdr.GetString(1);
      }
      DB.CloseConnection();
      return (new Specialty(specialty,sid));
    }

    public static void DeleteAll(bool saveUniqueIds = true)
    {
      DB.ClearTable(_tableName,saveUniqueIds);
      DB.ClearTable(_tableRelational,saveUniqueIds);
    }

    public static void DeleteId(int deleteId)
    {
      DB.DeleteById(_tableName,deleteId);
      DB.DeleteBy(_tableRelational,"specialtyId",deleteId);
    }

    public void Delete()
    {
      DB.DeleteById(_tableName,_id);
      DB.DeleteBy(_tableRelational,"specialtyId",_id);
    }

    public static bool ReturnTrue()
    {
      return true;
    }

    public override bool Equals(System.Object otherItem)
    {
      if (otherItem is Specialty)
      {
        Specialty newItem = (Specialty) otherItem;
        return this.GetId().Equals(newItem.GetId());
      }
      else
      {
        return false;
      }
    }

    public override int GetHashCode()
    {
      return this.GetSpecialty().GetHashCode();
    }


  }
}
