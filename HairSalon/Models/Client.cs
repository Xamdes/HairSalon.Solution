using System;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;


namespace HairSalon.Models
{
  public class Client
  {
    private string _name;
    private int _id;
    private int _stylistId;

    public Client(string name,int stylistId)
    {
      _name = name;
      _stylistId = stylistId;
    }

    public string GetName()
    {
      return _name;
    }
    public SetName(string name)
    {
      _name = name;
    }

    public string GetId()
    {
      return _id;
    }
    public SetId(int id)
    {
      _id = id;
    }

    public string GetStylist()
    {
      return _stylistId;
    }
    public SetStylist(int stylistId)
    {
      _stylistId = stylistId;
    }

  }
}
