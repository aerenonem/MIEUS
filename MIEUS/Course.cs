using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIEUS
{
    class Course
    {
        public static int uniqueID = 0;
        public int ID { get; set; }
        public string name { get; set; }
        public List<Student> Students { get; set; }
        public Instructor Instructor { get; set; }
        public Course(string name,Instructor Instructor)
        {
            Students = new List<Student>();
            this.name = name;
            this.Instructor = Instructor;
            this.ID = uniqueID;
            uniqueID++;
        }
        public void displayCourseInformation()
        {
            Console.WriteLine("Course ID: "+ID+" Course Name: " + name);
            Instructor.toString();
            if (Students.Count != 0)
            {
                Console.WriteLine("\nStudents\n");
                int count = 1;
                foreach (Student s in Students)
                {
                    Console.Write(count + ") ");
                    s.toString();
                }
                
            }
            else
            {
                Console.WriteLine("No students added to this course.\n");
            }
            Console.WriteLine("-------------------------------");
        }

        public void editInformation()
        {
            while (true)
            {
                Console.WriteLine("\nChoose the information that you want to change.\n0) Exit\n1) Name");

                int choice = -1;
                string change;

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    if (choice > -1 && choice < 2)
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
        public void toString()
        {
            Console.WriteLine("Course ID : " + ID + " " + name);
            Console.WriteLine("-------------------------------");
        }
    }
}
