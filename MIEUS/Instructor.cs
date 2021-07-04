using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIEUS
{
    class Instructor:Person
    {
        public List<Course> Courses { get; set; }
        public Instructor(string name, string surname, string address, string username, string password)
            : base(name, surname, address, username, password)
        {
            Courses = new List<Course>();
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
        public Student getHighestGradeStudent()
        {
            int max = 0;
            Student result = null;

            foreach (Course c in Courses)
            {
                foreach (Student s in c.Students)
                {
                    if(max < s.ExamResults[s.getHighestGradeCourseID()])
                    {
                        result = s;
                        max = s.ExamResults[s.getHighestGradeCourseID()];
                    }
                                      
                }
            }

            if (result == null)
            {
                Console.WriteLine("There are no students in this course.\n");
            }

            return result;
        }
        public void getFailedStudents()
        {
            int flag = 0;

            foreach (Course c in Courses)
            {
                foreach (Student s in c.Students)
                {
                  
                    foreach(KeyValuePair<int, int> entry in s.ExamResults)
                    {
                        if(entry.Value < 60)
                        {
                            flag = 1;
                            s.toString();
                        }
                    }

                }
            }
            if(flag == 0)
            {
                Console.WriteLine("Nobody failed the course.\n");

            }
            Console.WriteLine("-------------------------------");
        }
        public override void toString()
        {
            Console.WriteLine("Instructor ID : " + this.ID + " " + this.name + " " + this.surname + " " + this.address + " " + this.username + " " + this.password);

            if (Courses.Count != 0)
            {
                foreach(Course c in Courses)
                {
                    c.toString();
                }
            }
            else
            {
                Console.WriteLine("Instructor has no course.\n");
            }

            Console.WriteLine("-------------------------------");
        }
    }
}
