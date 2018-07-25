using System;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using HairSalon;

namespace HairSalon.Models
{
  public class DB
  {
    private static MySqlConnection _conn;
    private static MySqlCommand _cmd;
    private static string _connectionString = DBConfiguration.GetConnection();
    public delegate void Del(MySqlDataReader rdr, List<Object> objects);


    public static MySqlConnection GetConnection()
    {
      return _conn;
    }

    public static void OpenConnection()
    {
      _conn = new MySqlConnection(_connectionString);
      _conn.Open();
      _cmd = _conn.CreateCommand() as MySqlCommand;
    }

    public static void CloseConnection()
    {
      _conn.Close();
      if(_conn!=null)
      {
        _conn.Dispose();
      }
      _cmd = null;
    }

    public static void ResetCommand()
    {
      _cmd = _conn.CreateCommand() as MySqlCommand;
    }

    public static void AddParameter(string name, Object parameterValue)
    {
      _cmd.Parameters.Add(new MySqlParameter(name, parameterValue));
    }

    public static void AddParameter(MySqlParameter para)
    {
      _cmd.Parameters.Add(para);
    }

    public static void SetCommand(string commandText)
    {
      _cmd.CommandText = commandText;
    }

    public static void RunSqlCommand()
    {
      _cmd.ExecuteNonQuery();
    }

    public static MySqlDataReader ReadSqlCommand()
    {
      return (_cmd.ExecuteReader() as MySqlDataReader);
    }

    public static void ReadTable(Del callback, List<Object> objects)
    {
      MySqlDataReader rdr = ReadSqlCommand();
      while(rdr.Read())
      {
        callback(rdr,objects);
      }
    }

    public static void Edit(string tableName,int id, string what,  Object editValue)
    {
      OpenConnection();
      SetCommand(@"UPDATE "+tableName+" SET "+what+" = @updateValue WHERE id = @searchId;");
      AddParameter("@searchId",id);
      AddParameter("@updateValue",editValue);
      RunSqlCommand();
      CloseConnection();
    }

    public static void ClearTable(string tableName, bool saveUniqueIds = true)
    {
      OpenConnection();
      if(saveUniqueIds)
      {
        SetCommand(@"DELETE FROM "+tableName+";");
      }
      else
      {
        SetCommand(@"TRUNCATE TABLE "+tableName+";");
      }
      RunSqlCommand();
      CloseConnection();
    }

    public static void DeleteById(string tableName, int deleteId)
    {
      OpenConnection();
      SetCommand(@"DELETE FROM "+tableName+" WHERE id=@id");
      AddParameter("@id",deleteId);
      RunSqlCommand();
      CloseConnection();
    }

    public static void DeleteBy(string tableName,string what, int id)
    {
      OpenConnection();
      SetCommand(@"DELETE FROM "+tableName+" WHERE "+what+"=@id");
      AddParameter("@id",id);
      RunSqlCommand();
      CloseConnection();
    }

    public static void SaveToTable(string tableName,string columns,List<string> values,List<Object> parameters)
    {
      string valueNames = string.Join(",",values);
      SetCommand(@"INSERT INTO "+tableName+" ("+columns+") VALUES ("+valueNames+");");
      int i = 0;
      foreach(Object o in parameters)
      {
        AddParameter(values[i], parameters[i]);
        i++;
      }
      RunSqlCommand();
    }

    public static int LastInsertId()
    {
      return (int) _cmd.LastInsertedId;
    }

    public static int LastTableId(string tableName, string sid = "id")
    {
      int id = -1;
      OpenConnection();
      SetCommand(@"SELECT Max("+sid+") FROM "+tableName+";");
      MySqlDataReader rdr = ReadSqlCommand();
      while(rdr.Read())
      {
        id = rdr.GetInt32(0);
      }
      CloseConnection();
      return id;
    }
  }
}



/*
CREATE TABLE `sc_todolist`.`items` ( `id` INT NOT NULL AUTO_INCREMENT , `description` VARCHAR(255) NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;
*/
