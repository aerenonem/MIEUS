using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIEUS
{
    abstract class Person
    {

        public static int unique_ID = 0;
        public int ID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string address { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public Person(string name, string surname, string address,string username,string password)
        {
            this.ID = unique_ID;
            unique_ID++;
            this.name = name;
            this.surname = surname;
            this.address = address;
            this.username = username;
            this.password = password;          
        }
        public abstract void toString();


    }
}
