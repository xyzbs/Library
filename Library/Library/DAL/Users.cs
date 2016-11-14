using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class Users : Attribute
    {
        public int id;
        public string Name;
        public  Users(int id,string Name)
        {
            this.id = id;
            this.Name = Name;
        }     
        public Users(string Name)
        {
            this.Name = Name;
        }
    }
}