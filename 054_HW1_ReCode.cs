using System;
using System.Collections.Generic;
enum Menu
{
    RegisterNewStudent = 1,
    RegisterNewTeacher,
    GetListPersons
}

namespace StuTeache
{
    class Program
    {
        static void Main(string[] args)
        {
            PrepareList.PreparePersonListWhenProgramIsLoad();
            PrintMenuScreen();
        }

        static void PrintMenuScreen()
        {
            Console.Clear();
            ShowHeader.PrintHeader();
            ShowHeader.PrintListMenu();
            InputMenuFromKeyboard();
        }

        static void InputMenuFromKeyboard()
        {
            Console.Write("Please Select Menu: ");
            Menu menu = (Menu)(int.Parse(Console.ReadLine()));

            PresentMenu(menu);
        }

        static void PresentMenu(Menu menu)
        {
            if (menu == Menu.RegisterNewStudent)
            {
                ShowInputRegisterNewStudentScreen();
            }
            else if (menu == Menu.RegisterNewTeacher)
            {
                ShowInputRegisterNewTeacherScreen();
            }
            else if (menu == Menu.GetListPersons)
            {
                ShowGetListPersonScreen();
            }
            else
            {
                ShowMessageInputMenuIsInCorrect();
            }
        }

        static void ShowInputRegisterNewStudentScreen()
        {
            Console.Clear();
            ShowHeader.PrintHeaderRegisterStudent();

            int totalStudent = InputInformation.TotalNewStudents();
            InputNewStudentFromKeyboard(totalStudent);
        }

        static void ShowInputRegisterNewTeacherScreen()
        {
            Console.Clear();
            ShowHeader.PrintHeaderRegisterTeacher();

            int totalTeacher = InputInformation.TotalNewTeacher();
            InputNewTeacherFromKeyboard(totalTeacher);
        }

        static void ShowGetListPersonScreen()
        {
            Console.Clear();
            PrepareList.personList.FetchPersonsList();
            InputExitFromKeyboard();
        }

        static void InputExitFromKeyboard()
        {
            string text = "";
            while (text != "exit")
            {
                Console.WriteLine("Input: ");
                text = Console.ReadLine();
            }

            Console.Clear();
            PrintMenuScreen();
        }

        static void InputNewTeacherFromKeyboard(int totalTeacher)
        {
            for (int i = 0; i < totalTeacher; i++)
            {
                Console.Clear();
                ShowHeader.PrintHeaderRegisterTeacher();

                Teacher teacher = CreateNewPerson.CreateNewTeacher();
                PrepareList.personList.AddNewPerson(teacher);
            }

            Console.Clear();
            PrintMenuScreen();
        }

        static void InputNewStudentFromKeyboard(int totalStudent)
        {
            for (int i = 0; i < totalStudent; i++)
            {
                Console.Clear();
                ShowHeader.PrintHeaderRegisterStudent();

                Student student = CreateNewPerson.CreateNewStudent();
                PrepareList.personList.AddNewPerson(student);
            }

            Console.Clear();
            PrintMenuScreen();
        }

        static void ShowMessageInputMenuIsInCorrect()
        {
            Console.Clear();
            Console.WriteLine("Menu Incorrect Please try again.");
            InputMenuFromKeyboard();
        }
    }

    class ShowHeader
    {
        public static void PrintHeader()
        {
            Console.WriteLine("Welcome to registration new user school application.");
            Console.WriteLine("----------------------------------------------------");
        }

        public static void PrintListMenu()
        {
            Console.WriteLine("1. Register new student.");
            Console.WriteLine("2. Register new Teacher.");
            Console.WriteLine("3. Get List Persons.");
        }

        public static void PrintHeaderRegisterStudent()
        {
            Console.WriteLine("Register new student.");
            Console.WriteLine("---------------------");
        }

        public static void PrintHeaderRegisterTeacher()
        {
            Console.WriteLine("Register new teacher.");
            Console.WriteLine("---------------------");
        }
    }

    class CreateNewPerson
    {
        public static Student CreateNewStudent()
        {
            return new Student(InputInformation.InputName(),
             InputInformation.InputAddress(),
             InputInformation.InputCitizenID(),
             InputInformation.InputStudentID());
        }

        public static Teacher CreateNewTeacher()
        {
            return new Teacher(InputInformation.InputName(),
            InputInformation.InputAddress(),
            InputInformation.InputCitizenID(),
            InputInformation.InputEmployeeID());
        }
    }

    class InputInformation
    {
        public static string InputName()
        {
            Console.Write("Name: ");
            return Console.ReadLine();
        }

        public static string InputStudentID()
        {
            Console.Write("Student ID: ");
            return Console.ReadLine();
        }

        public static string InputAddress()
        {
            Console.Write("Address: ");
            return Console.ReadLine();
        }

        public static string InputCitizenID()
        {
            Console.Write("Citizen ID: ");
            return Console.ReadLine();
        }

        public static string InputEmployeeID()
        {
            Console.Write("Employee ID: ");
            return Console.ReadLine();
        }

        public static int TotalNewStudents()
        {
            Console.Write("Input Total new Student: ");
            return int.Parse(Console.ReadLine());
        }

        public static int TotalNewTeacher()
        {
            Console.Write("Input Total new Teacher: ");
            return int.Parse(Console.ReadLine());
        }
    }

    class PrepareList
    {
        public static PersonList personList;

        public static void PreparePersonListWhenProgramIsLoad()
        {
            PrepareList.personList = new PersonList();
        }
    }

    class Person
    {
        protected string name;
        protected string address;
        protected string citizenID;

        public Person(string name, string address, string citizenID)
        {
            this.name = name;
            this.address = address;
            this.citizenID = citizenID;
        }

        public string GetName()
        {
            return this.name;
        }

    }

    class PersonList
    {
        private List<Person> personList;

        public PersonList()
        {
            this.personList = new List<Person>();
        }

        public void AddNewPerson(Person person)
        {
            this.personList.Add(person);
        }

        public void FetchPersonsList()
        {
            Console.WriteLine("List Persons");
            Console.WriteLine("---------------------");
            foreach (Person person in this.personList)
            {
                if (person is Student)
                {
                    Console.WriteLine("Name: {0} \nType: Student \n", person.GetName());
                }
                else if (person is Teacher)
                {
                    Console.WriteLine("Name: {0} \nType: Teacher \n", person.GetName());
                }
            }
        }
    }

    class Student : Person
    {
        private string studentID;

        public Student(string name, string address, string citizenID, string studentID)
        : base(name, address, citizenID)
        {
            this.studentID = studentID;
        }

    }

    class Teacher : Person
    {
        private string employeeID;

        public Teacher(string name, string address, string citizenID, string employeeID)
        : base(name, address, citizenID)
        {
            this.employeeID = employeeID;
        }

    }

}
