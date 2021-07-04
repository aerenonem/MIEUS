using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIEUS
{
    class test_MIEUS
    {

        public static void LoadTxts(MIEUS MIEUS)
        {
            string[] lines = File.ReadAllLines("C:\\Users\\PC\\Desktop\\MIEUS\\MIEUS\\studentInfo.txt");

            string[] splitted;

            foreach (string line in lines)
            {
                splitted = line.Split();

                MIEUS.People.Add(new Student(splitted[0], splitted[1], splitted[2], splitted[3], splitted[4]));
            }

            lines = File.ReadAllLines("C:\\Users\\PC\\Desktop\\MIEUS\\MIEUS\\instructorInfo.txt");

            foreach (string line in lines)
            {
                splitted = line.Split();

                MIEUS.People.Add(new Instructor(splitted[0], splitted[1], splitted[2], splitted[3], splitted[4])); 
            }

            lines = File.ReadAllLines("C:\\Users\\PC\\Desktop\\MIEUS\\MIEUS\\backEmployeeInfo.txt");

            foreach (string line in lines)
            {
                splitted = line.Split();

                MIEUS.People.Add(new BackEmployee(splitted[0], splitted[1], splitted[2], splitted[3], splitted[4]));
            }

            lines = File.ReadAllLines("C:\\Users\\PC\\Desktop\\MIEUS\\MIEUS\\systemAdminInfo.txt");

            foreach (string line in lines)
            {
                splitted = line.Split();

                MIEUS.People.Add(new SystemAdmin(splitted[0], splitted[1], splitted[2], splitted[3], splitted[4]));
            }

        }
        
        public static bool Login(MIEUS MIEUS)
        {
            bool flag = false;

            Console.WriteLine("Welcome to the MIEUS. You must login into the system. Press 0 for exit.\n");

            Console.WriteLine("Please enter the username: ");
            string username = Console.ReadLine();

            if (username.Equals("0"))
            {
                Console.WriteLine("MIEUS Closed.");
                Environment.Exit(0);
                return false;
            }

            Console.WriteLine("Please enter the password: ");
            string password = Console.ReadLine();

            foreach (Person p in MIEUS.People)
            {
              if(p.username.Equals(username) && p.password.Equals(password))
                {
                    MIEUS.CurrentPersonID = p.ID;
                    flag = true;
                    string now = DateTime.Now.ToString("ddd, dd MMM yyy HH’:’mm’:’ss ‘GMT’");

                    string login_string = MIEUS.People[MIEUS.getPersonIndexByID(p.ID)].name+" "+ MIEUS.People[MIEUS.getPersonIndexByID(p.ID)].surname+" "+now;
                    MIEUS.LoginHistory.Add(login_string);
                    MIEUS.isUpdated = false;
                    break;
                }
            }


            return flag;
        }
        
        public static void SystemAdminPerspective(MIEUS MIEUS)
        {

            SystemAdmin sa = (SystemAdmin)MIEUS.People[MIEUS.getPersonIndexByID(MIEUS.CurrentPersonID)];

            while (true)
            {
                int choice = -1;

                Console.WriteLine("\n0) Exit\n1) Add Back Employee\n2) Edit Back Employee\n3) Delete Back Employee\n4) Save Login History\nChoice: ");

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());

                    if (choice > -1 && choice < 5)
                    {
                        switch (choice)
                        {
                            case 0:
                                Console.WriteLine("Exited.\n");
                                break;
                            case 1:
                                sa.EmployeeCRUD("Add",MIEUS);
                                break;
                            case 2:
                                sa.EmployeeCRUD("Edit", MIEUS);
                                break;
                            case 3:
                                sa.EmployeeCRUD("Delete", MIEUS);
                                break;
                            case 4:
                                sa.loginHistorySave(MIEUS);
                                break;
                        }
                        if (choice == 0)
                            break;
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

        public static void BackEmployeePerspective(MIEUS MIEUS)
        {
            BackEmployee be = (BackEmployee)MIEUS.People[MIEUS.getPersonIndexByID(MIEUS.CurrentPersonID)];

            while (true)
            {
                int choice = -1;



                Console.WriteLine("\n" +
                    "0) Exit\n" +
                    "1) Add Instructor\n" +
                    "2) Edit Instructor\n" +
                    "3) Delete Instructor\n" +
                    "4) Display Instructor\n" +
                    "5) Add Course\n" +
                    "6) Edit Course\n" +
                    "7) Delete Course\n" +
                    "8) Display Course\n" +
                    "9) Add Student\n" +
                    "10) Edit Student\n" +
                    "11) Delete Student\n" +
                    "12) Display Student\n" +
                    "13) Add Student to Course\n" +
                    "Choice: ");

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    if (choice > -1 && choice < 14)
                    {                  

                        switch (choice)
                        {
                            case 0:
                                Console.WriteLine("Exited.");
                                break;
                            case 1:
                                be.InstructorCRUD("Add", MIEUS);
                                break;
                            case 2:
                                be.InstructorCRUD("Edit", MIEUS);
                                break;
                            case 3:
                                be.InstructorCRUD("Delete", MIEUS);
                                break;
                            case 4:
                                be.InstructorCRUD("Display", MIEUS);
                                break;
                            case 5:
                                be.CourseCRUD("Add", MIEUS);
                                break;
                            case 6:
                                be.CourseCRUD("Edit", MIEUS);
                                break;
                            case 7:
                                be.CourseCRUD("Delete", MIEUS);
                                break;
                            case 8:
                                be.CourseCRUD("Display", MIEUS);
                                break;
                            case 9:
                                be.StudentCRUD("Add", MIEUS);
                                break;
                            case 10:
                                be.StudentCRUD("Edit", MIEUS);
                                break;
                            case 11:
                                be.StudentCRUD("Delete", MIEUS);
                                break;
                            case 12:
                                be.StudentCRUD("Display", MIEUS);
                                break;
                            case 13:
                                be.addStudentToCourse(MIEUS);
                                break;
                        }
                        if (choice == 0)
                            break;
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

        public static void InstructorPerspective(MIEUS MIEUS)
        {
            while (true)
            {
                int choice = -1;

                Console.WriteLine("\n0) Exit\n1) Enter Exam Results\n2) Edit Information\n3) Display Course Info\n" +
                    "4) Display Highest Mark Student\n5) Display Failed Students\nChoice: ");

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());

                    if (choice > -1 && choice < 6)
                    {
                        switch (choice)
                        {
                            case 0:
                                Console.WriteLine("Exited.\n");
                                break;
                            case 1:
                                int result = MIEUS.personSelectableMenu(typeof(Student));
                                if(result != -1)
                                {
                                    int result2 = MIEUS.courseSelectableMenu(result);

                                    if (result2 != -1)
                                    {
                                        try
                                        {
                                            Console.Write("Please enter the grade: ");
                                            int grade = Convert.ToInt32(Console.ReadLine());

                                            Student s = (Student)MIEUS.People[result];

                                            s.ExamResults.Add(result2, grade);

                                            Console.WriteLine("Grade added.\n");

                                        }
                                        catch
                                        {
                                            Console.WriteLine("Please enter a number.\n");
                                        }
                                    }
                                }
                                
                                break;
                            case 2:
                                Instructor i = (Instructor)MIEUS.People[MIEUS.getPersonIndexByID(MIEUS.CurrentPersonID)];
                                i.editInformation();
                                break;
                            case 3:
                                result = MIEUS.courseSelectableMenu(-1);
                                break;
                            case 4:
                                i = (Instructor)MIEUS.People[MIEUS.getPersonIndexByID(MIEUS.CurrentPersonID)];
                                if (i.getHighestGradeStudent() != null)
                                {
                                   Console.WriteLine("Highest grade student is : ");
                                   i.getHighestGradeStudent().toString();
                                   Console.WriteLine("From the Course: " + MIEUS.Courses[MIEUS.getCourseIndexByID(i.getHighestGradeStudent().getHighestGradeCourseID())].name);
                                }                           
                                break;
                            case 5:
                                i = (Instructor)MIEUS.People[MIEUS.getPersonIndexByID(MIEUS.CurrentPersonID)];
                                Console.WriteLine("Failed Students are : ");
                                i.getFailedStudents();
                                break;
                        }
                        if (choice == 0)
                            break;
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

        public static void StudentPerspective(MIEUS MIEUS)
        {
            while (true)
            {
                int choice = -1;

                Console.WriteLine("\n0) Exit\n1) Display Transcript\n2) Edit Information\nChoice: ");

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    if(choice != 0 && choice !=1 && choice != 2)
                    {
                        Console.WriteLine("Please enter a valid choice.");
                    }
                    else
                    {
                        if (choice == 1)
                        {
                            Student s = (Student)MIEUS.People[MIEUS.getPersonIndexByID(MIEUS.CurrentPersonID)];
                            s.displayTranscript();
                        }
                        else if(choice==2)
                        {
                            Student s = (Student)MIEUS.People[MIEUS.getPersonIndexByID(MIEUS.CurrentPersonID)];
                            s.editInformation();
                        }
                        else
                        {
                            Console.WriteLine("\nExited.\n");
                            break;
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter a number.");
                }

                

            }
        }

        static void Main(string[] args)
        {

            MIEUS MIEUS = new MIEUS();

            LoadTxts(MIEUS);

            Console.WriteLine("Txts loaded.\n");
        
            while (true)
            {
                bool isLogged = Login(MIEUS);

                if (isLogged)
                {
                    Console.WriteLine("Hello " + MIEUS.People[MIEUS.getPersonIndexByID(MIEUS.CurrentPersonID)].name);

                    if (MIEUS.People[MIEUS.getPersonIndexByID(MIEUS.CurrentPersonID)].GetType() == typeof(Student))
                    {
                        StudentPerspective(MIEUS);
                    }
                    else if(MIEUS.People[MIEUS.getPersonIndexByID(MIEUS.CurrentPersonID)].GetType() == typeof(Instructor))
                    {
                        InstructorPerspective(MIEUS);
                    }
                    else if (MIEUS.People[MIEUS.getPersonIndexByID(MIEUS.CurrentPersonID)].GetType() == typeof(SystemAdmin))
                    {
                        SystemAdminPerspective(MIEUS);
                    }
                    else if (MIEUS.People[MIEUS.getPersonIndexByID(MIEUS.CurrentPersonID)].GetType() == typeof(BackEmployee))
                    {
                        BackEmployeePerspective(MIEUS);
                    }

                }
                else
                {
                    Console.WriteLine("\nWrong username or password.\n");
                }
            }

        }
    }
}
