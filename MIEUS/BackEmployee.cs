using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIEUS
{
    class BackEmployee:Person
    {

       public BackEmployee(string name, string surname, string address, string username, string password)
           : base(name, surname, address, username, password)
        {

        }
        public void InstructorCRUD(string process,MIEUS MIEUS)
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

                Instructor to_be_added = new Instructor(property_1, property_2, property_3, property_4, property_5);

                MIEUS.People.Add(to_be_added);

            }
            else if (process.Equals("Edit"))
            {
                int selected = MIEUS.personSelectableMenu(typeof(Instructor));

                if (selected != -1)
                {
                    Instructor i = (Instructor)MIEUS.People[MIEUS.getPersonIndexByID(selected)];
                    i.editInformation();
                }

            }
            else if (process.Equals("Delete"))
            {
                List<int> to_be_deleted = new List<int>();

                int selected = MIEUS.personSelectableMenu(typeof(Instructor));

                if (selected != -1)
                {
                    Instructor i = (Instructor)MIEUS.People[MIEUS.getPersonIndexByID(selected)];

                    foreach(Course c in i.Courses)//Verdiği dersler silindi
                    {
                        MIEUS.Courses.RemoveAt(MIEUS.getCourseIndexByID(c.ID));
                    }

                    foreach (Person p in MIEUS.People)
                    {
                        if (p.GetType() == typeof(Student))
                        {
                            Student s = (Student)p;

                            for(int j = 0; j < s.Courses.Count; j++)
                            {
                                if (s.Courses[j].Instructor.ID == selected)
                                {
                                    to_be_deleted.Add(j);
                                }
                            }

                            for(int j = 0; j < to_be_deleted.Count; j++)
                            {
                                s.Courses.RemoveAt(to_be_deleted[j]);
                            }
                        }

                    }

                    MIEUS.People.RemoveAt(MIEUS.getPersonIndexByID(selected));//Kendisi silindi

                    

                    Console.WriteLine("Instructor deleted.");
                }

            }
            else if (process.Equals("Display"))
            {
                int selected = MIEUS.personSelectableMenu(typeof(Instructor));

                if (selected != -1)
                {

                    Instructor i = (Instructor)MIEUS.People[MIEUS.getPersonIndexByID(selected)];
                    i.toString();
                }

            }

        }
        public void StudentCRUD(string process, MIEUS MIEUS)
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

                Student to_be_added = new Student(property_1, property_2, property_3, property_4, property_5);

                MIEUS.People.Add(to_be_added);

            }
            else if (process.Equals("Edit"))
            {
                int selected = MIEUS.personSelectableMenu(typeof(Student));

                if (selected != -1)
                {
                    Student i = (Student)MIEUS.People[MIEUS.getPersonIndexByID(selected)];
                    i.editInformation();
                }

            }
            else if (process.Equals("Delete"))
            {
                int selected = MIEUS.personSelectableMenu(typeof(Student));

                if (selected != -1)
                {

                    MIEUS.People.RemoveAt(MIEUS.getPersonIndexByID(selected));

                    List<int> to_be_deleted = new List<int>();

                    foreach (Person p in MIEUS.People)
                    {
                        if (p.GetType() == typeof(Student))
                        {
                            Student s = (Student)p;

                            for (int j = 0; j < s.Courses.Count; j++)
                            {
                               
                                for(int k = 0; k < s.Courses[j].Students.Count; k++)
                                {
                                    if (s.Courses[j].Students[k].ID == selected)
                                    {
                                        to_be_deleted.Add(k);
                                    }
                                }
                            }

                            for (int j = 0; j < s.Courses.Count; j++)
                            {

                                for (int k = 0; k < s.Courses[j].Students.Count; k++)
                                {

                                   s.Courses[j].Students.RemoveAt(to_be_deleted[k]);

                                }
                            }

                            to_be_deleted = new List<int>();

                        }
                        else if (p.GetType() == typeof(Instructor))
                        {
                            Instructor s = (Instructor)p;

                            for (int j = 0; j < s.Courses.Count; j++)
                            {

                                for (int k = 0; k < s.Courses[j].Students.Count; k++)
                                {
                                    if (s.Courses[j].Students[k].ID == selected)
                                    {
                                        to_be_deleted.Add(k);
                                    }
                                }
                            }

                            for (int j = 0; j < s.Courses.Count; j++)
                            {

                                for (int k = 0; k < s.Courses[j].Students.Count; k++)
                                {

                                    s.Courses[j].Students.RemoveAt(to_be_deleted[k]);

                                }
                            }


                            to_be_deleted = new List<int>();
                        }
                    }
   
                    Console.WriteLine("Student deleted.");
                }

            }
            else if (process.Equals("Display"))
            {
                int selected = MIEUS.personSelectableMenu(typeof(Student));

                if (selected != -1)
                {

                    Student i = (Student)MIEUS.People[MIEUS.getPersonIndexByID(selected)];
                    i.toString();
                }

            }

        }
        public void CourseCRUD(string process, MIEUS MIEUS)
        {

            string property_1;

            if (process.Equals("Add"))
            {

                int selected = MIEUS.personSelectableMenu(typeof(Instructor));

                if (selected != -1)
                {
                    Instructor i = (Instructor)MIEUS.People[MIEUS.getPersonIndexByID(selected)];
                    Console.Write("Course Name: ");
                    property_1 = Console.ReadLine();
                    Course C = new Course(property_1, i);
                    i.Courses.Add(C);
                    MIEUS.Courses.Add(C);
                    Console.WriteLine("Course added.\n");
                }
            }
            else if (process.Equals("Edit"))
            {
                int selected = MIEUS.courseSelectableMenu(-1);

                if (selected != -1)
                {
                    MIEUS.Courses[MIEUS.getCourseIndexByID(selected)].editInformation();
                }

            }
            else if (process.Equals("Delete"))
            {
                int selected = MIEUS.courseSelectableMenu(-1);

                if (selected != -1)
                {

                    List<int> to_be_deleted = new List<int>();

                    foreach(Person p in MIEUS.People)
                    {
                        if (p.GetType() == typeof(Student))
                        {
                            Student s = (Student)p;

                            for(int j = 0; j < s.Courses.Count; j++)
                            {
                                if (s.Courses[j].ID == selected)
                                {
                                    to_be_deleted.Add(j);
                                }
                            }

                            for (int j = 0; j < to_be_deleted.Count; j++)
                            {
                                s.Courses.RemoveAt(to_be_deleted[j]);
                            }

                            to_be_deleted = new List<int>();

                        }
                        else if (p.GetType() == typeof(Instructor))
                        {
                            Instructor s = (Instructor)p;

                            for (int j = 0; j < s.Courses.Count; j++)
                            {
                                if (s.Courses[j].ID == selected)
                                {
                                    to_be_deleted.Add(j);
                                }
                            }

                            for (int j = 0; j < to_be_deleted.Count; j++)
                            {
                                s.Courses.RemoveAt(to_be_deleted[j]);
                            }

                            to_be_deleted = new List<int>();
                        }
                    }


                    MIEUS.Courses.RemoveAt(MIEUS.getCourseIndexByID(selected));
                    Console.WriteLine("Course deleted.\n");
                }

            }
            else if (process.Equals("Display"))
            {
                int selected = MIEUS.courseSelectableMenu(-1);

                if (selected != -1)
                {
                    MIEUS.Courses[MIEUS.getCourseIndexByID(selected)].displayCourseInformation();
                }

            }

        }     
        public void addStudentToCourse(MIEUS MIEUS)
        {
            int result = MIEUS.courseSelectableMenu(-1);

            if (result != -1)
            {
                int result2 = MIEUS.personSelectableMenu(typeof(Student));

                if (result2 != -1)
                {
                    Student i = (Student)MIEUS.People[MIEUS.getPersonIndexByID(result2)];

                    i.Courses.Add(MIEUS.Courses[MIEUS.getCourseIndexByID(result)]);//Student içindeki courses
                    MIEUS.Courses[MIEUS.getCourseIndexByID(result)].Students.Add(i);//Courses içindeki student

                    Console.WriteLine("Student added to the Course.\n");
                }
            }
        }
       public void editInformation()
        {
            while (true)
            {
                Console.WriteLine("\nChoose the information that you want to change.\n0) Exit\n1) Name\n2) Surname\n3) Address\n4) Username\n5) Password");

                int choice = -1;
                string change;

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    if (choice > -1 && choice < 6)
                    {
                        Console.WriteLine("Enter the new value: ");
                        switch (choice)
                        {
                            case 0:
                                Console.WriteLine("Exited.");
                                break;
                            case 1:
                                change = Console.ReadLine();
                                this.name = change;
                                break;
                            case 2:
                                change = Console.ReadLine();
                                this.surname = change;
                                break;
                            case 3:
                                change = Console.ReadLine();
                                this.address = change;
                                break;
                            case 4:
                                change = Console.ReadLine();
                                this.username = change;
                                break;
                            case 5:
                                change = Console.ReadLine();
                                this.password = change;
                                break;
                        }
                        if (choice == 0)
                            break;
                        Console.WriteLine("Information changed.");
                        toString();
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid choice.");
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter a number.");
                }

            }

        }
        public override void toString()
        {
            Console.WriteLine("BackEmployee ID : "+ this.ID + " " + this.name + " " + this.surname + " " + this.address + " " + this.username + " " + this.password);
            Console.WriteLine("-------------------------------");
        }
    }
}
