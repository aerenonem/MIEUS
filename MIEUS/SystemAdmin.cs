using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIEUS
{
    class SystemAdmin : Person
    {
        public SystemAdmin(string name, string surname, string address, string username, string password)
            : base(name, surname, address, username, password){
        }

        public void EmployeeCRUD(string process, MIEUS MIEUS)
        {
            string property_1, property_2, property_3, property_4, property_5;

            if (process.Equals("Add"))
            {
                Console.Write("Name: ");
                property_1 = Console.ReadLine();
                Console.Write("Surname: ");
                property_2 = Console.ReadLine();
                Console.Write("Address: ");
                property_3 = Console.ReadLine();
                Console.Write("Username: ");
                property_4 = Console.ReadLine();
                Console.Write("Password: ");
                property_5 = Console.ReadLine();

                BackEmployee to_be_added = new BackEmployee(property_1, property_2, property_3, property_4, property_5);

                MIEUS.People.Add(to_be_added);

            }
            else if (process.Equals("Edit"))
            {
                int selected = MIEUS.personSelectableMenu(typeof(BackEmployee));

                if (selected != -1)
                {
                    BackEmployee i = (BackEmployee)MIEUS.People[MIEUS.getPersonIndexByID(selected)];
                    i.editInformation();
                }

            }
            else if (process.Equals("Delete"))
            {

                int selected = MIEUS.personSelectableMenu(typeof(BackEmployee));

                if (selected != -1)
                {

                    MIEUS.People.RemoveAt(MIEUS.getPersonIndexByID(selected));
                    Console.WriteLine("Back Employee deleted.");
                }

            }
            else if (process.Equals("Display"))
            {
                int selected = MIEUS.personSelectableMenu(typeof(BackEmployee));

                if (selected != -1)
                {

                    BackEmployee i = (BackEmployee)MIEUS.People[MIEUS.getPersonIndexByID(selected)];
                    i.toString();
                }

            }
        }
        public void loginHistorySave(MIEUS MIEUS)
        {
            if (MIEUS.isUpdated)
            {
                Console.WriteLine("Txt is already up to date.\n");
            }
            else
            {

                var path = @"C:\\Users\\PC\\Desktop\\MIEUS\\MIEUS\\log.txt";

                string[] lines = MIEUS.LoginHistory.ToArray();


                File.WriteAllLines(path, lines);

                Console.WriteLine("File updated.\n");



                MIEUS.isUpdated = false;
            }
        }
        public override void toString()
        {
            Console.WriteLine("System Admin ID : " + this.ID + " " + this.name + " " + this.surname + " " + this.address + " " + this.username + " " + this.password);
        }
    }
}
