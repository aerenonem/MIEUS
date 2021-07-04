using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIEUS
{
    class Student : Person
    {
        public List<Course> Courses { get; set; }
        public Dictionary<int, int> ExamResults { get; set; }//Course ID - Grade
        public Student(string name,string surname,string address,string username,string password)
            :base(name,surname, address, username, password)
        {
            Courses = new List<Course>();
            ExamResults = new Dictionary<int, int>();
        }
        public void displayTranscript()
        {
            if (ExamResults.Count == 0)
            {
                Console.WriteLine("No courses has been added yet.");
            }
            else
            {
                Console.WriteLine("Transcript of " + this.name + " " + this.surname);

                foreach (KeyValuePair<int, int> entry in ExamResults)
                {
                    int course_index = getCourseIndex(entry.Key);
                    if (course_index != -1)
                    {
                        Console.WriteLine("Course Name: " + Courses[course_index].name + " Grade: " + entry.Value);
                    }
                }
            }
            Console.WriteLine("-------------------------------");
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
        public int getCourseIndex(int courseID)
        {
            int index = -1;
            for(int i = 0; i < Courses.Count; i++)
            {
                if (courseID == Courses[i].ID)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }   
        public int getHighestGradeCourseID()
        {
            int index = -1,max = 0;

            foreach (KeyValuePair<int, int> entry in ExamResults)
            {
                if(entry.Value > max)
                {
                    max = entry.Value;
                    index = entry.Key;
                }
            }


            return index;
        }    
        public override void toString()
        {
            Console.WriteLine("Student ID : " + this.ID + " " + this.name + " " + this.surname +" "+this.address+" "+this.username+" "+this.password);

            if (Courses.Count != 0)
            {
                Console.WriteLine("Courses: ");
                foreach (Course c in Courses)
                {
                    c.toString();
                }
            }
            Console.WriteLine("-------------------------------");
        }
    }
}
