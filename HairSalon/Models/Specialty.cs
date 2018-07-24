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

    public Specialty(string s)
    {
      _specialty = s;
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
      string columns = "specialty";
      List<string> valueNames = new List<string>(){"@Specialty"};
      List<Object> values = new List<Object>(){_specialty};
      DB.SaveToTable(_tableName,columns,valueNames,values);
      _id = DB.LastInsertId();
    }

    public void AddSpecialty(Specialty newSpecialty)
    {
      //Needs to update client
      newSpecialty.SetSpecialty(_id);
      newSpecialty.Save();
    }

    public void AddSpecialty(string s)
    {
      Specialty newSpecialty = new Specialty(s);
      newSpecialty.Save();
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
        Specialty newSpeciality = new Stylist(specialty,id);
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