using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;



namespace HairSalon.Models
{
  public class Stylist
  {
    private string _name;
    private int _id;
    private List<Client> clients;

    public Stylist(string name,int id = -1)
    {
      _name = name;
      _id = id;
      clients = new List<Client>(){};
    }

  }
}
