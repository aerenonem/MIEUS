using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIEUS
{
    class MIEUS
    {
        public List<Person> People { get; set; }

        public List<Course> Courses { get; set; }

        public List<string> LoginHistory { get; set; }

        public bool isUpdated { get; set; }

        public int CurrentPersonID { get; set; }

        public MIEUS()
        {
            People = new List<Person>();
            Courses = new List<Course>();
            CurrentPersonID = -1;
            LoginHistory = new List<string>();
            this.isUpdated = true;
        }

        public int getPersonIndexByID(int ID)
        {
            int index = -1;

            for (int i = 0; i < People.Count; i++)
            {
                if(People[i].ID== ID)
                {
                    index = i;
                    break;
                }
            }


            return index;

        }

        public int getCourseIndexByID(int ID)
        {
            int index = -1;

            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].ID == ID)
                {
                    index = i;
                    break;
                }
            }


            return index;

        }

        public int personSelectableMenu(Type t)
        {
            int choosen = -1;

            if(t == typeof(Student))
            {

                foreach (Person p in People)
                {
                    if (p.GetType() == typeof(Student))
                    {
                        p.toString();
                    }
                }
            }
            else if (t == typeof(Instructor))
            {
                foreach (Person p in People)
                {
                    if (p.GetType() == typeof(Instructor))
                    {
                        p.toString();
                    }
                }
            }
            else if (t == typeof(BackEmployee))
            {
                foreach (Person p in People)
                {
                    if (p.GetType() == typeof(BackEmployee))
                    {
                        p.toString();
                    }
                }
            }

            Console.WriteLine("\nPlease write down the ID of the person that you want to select.");

            try
            {
                choosen = Convert.ToInt32(Console.ReadLine());
               
                if (getPersonIndexByID(choosen) == -1 || People[getPersonIndexByID(choosen)].GetType()!=t)
                {
                    Console.WriteLine("Please enter a valid ID.\n");
                    choosen = -1;
                }
            }
            catch
            {
                choosen = -1;
                Console.WriteLine("Please enter a number.\n");
            }


            return choosen;

        }

        public int courseSelectableMenu(int index)
        {
            int choosen = -1;

            if (index == -1)
            {
                if (Courses.Count != 0)
                {
                    foreach (Course c in Courses)
                    {
                        c.toString();
                    }

                    try
                    {
                        Console.WriteLine("\nPlease write down the ID of the course that you want to select.");

                        choosen = Convert.ToInt32(Console.ReadLine());

                        if (getCourseIndexByID(choosen) == -1)
                        {
                            Console.WriteLine("Please enter a valid ID.\n");
                            choosen = -1;
                        }

                    }
                    catch
                    {
                        choosen = -1;
                        Console.WriteLine("Please enter a number.\n");
                    }
                }
                else
                {
                    Console.WriteLine("No courses has been added yet.\n");
                }

            }
            else if (index == -2)
            {
                if (Courses.Count != 0)
                {
                    foreach (Course c in Courses)
                    {
                        c.toString();
                    }

                    try
                    {
                        Console.WriteLine("\nPlease write down the ID of the course that you want to select.");

                        choosen = Convert.ToInt32(Console.ReadLine());

                        if (getCourseIndexByID(choosen) == -1)
                        {
                            Console.WriteLine("Please enter a valid ID.\n");
                            choosen = -1;
                        }
                        else
                        {
                            Courses[getCourseIndexByID(choosen)].displayCourseInformation();
                        }

                    }
                    catch
                    {
                        choosen = -1;
                        Console.WriteLine("Please enter a number.\n");
                    }
                }
                else
                {
                    Console.WriteLine("No courses has been added yet.\n");
                }
            }
            else if (People[index].GetType() == typeof(Student))
            {
                Student s = (Student)People[index];

                foreach(Course c in s.Courses)
                {
                    c.toString();
                }

                Console.WriteLine("\nPlease write down the ID of the course that you want to select.");

                try
                {
                    choosen = Convert.ToInt32(Console.ReadLine());

                    if (getCourseIndexByID(choosen) == -1)
                    {
                        Console.WriteLine("Please enter a valid ID.\n");
                        choosen = -1;
                    }

                }
                catch
                {
                    choosen = -1;
                    Console.WriteLine("Please enter a number.\n");
                }

            }




            return choosen;

        }

    }
}
