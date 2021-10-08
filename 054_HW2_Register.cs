using System;
using System.Collections.Generic;

namespace _054_HW_Register
{
    enum Menu
    {
        Login = 1,
        Register,
        Exit
    }

    class Program
    {
        static void Main(string[] args)
        {
            PrepareList.PreparePersonList();
            PrepareList.PrepareActivityList();
            MenuScreen();

        }

        static void MenuScreenHeader()
        {
            Console.WriteLine("Welcome To Acitivity Register Site");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register ID");
            Console.WriteLine("3. Exit");
        }

        static void MenuScreen()
        {
            MenuScreenHeader();
            MenuScreenInput();
        }

        static void MenuScreenInput()
        {
            Console.Write("Please Select Menu: ");
            Menu menu = (Menu)int.Parse(Console.ReadLine());

            MenuScreenSelectCheck(menu);
        }

        static void MenuScreenSelectCheck(Menu menu)
        {
            if (menu == Menu.Login)
            {
                Console.Clear();
                LoginMenu();
            }
            else if (menu == Menu.Register)
            {
                Console.Clear();
                RegisterMenu();
            }
            else if (menu == Menu.Exit)
            {
                
            }
            else
            {
                Console.Clear();
                MenuScreen();
            }
        }

        static void LoginMenu()
        {
            LoginMenuHeader();
            LoginMenuInput();
        }

        static void LoginMenuHeader()
        {
            Console.WriteLine("Login Menu");
            Console.WriteLine("----------");
        }

        static void LoginMenuInput()
        {
            string username = InputInformation.InputName();
            string password = InputInformation.InputPassword();

            CheckUsernamePassword(username, password);
        }

        static void CheckUsernamePassword(string username, string password)
        {
            int i = 0;
            int counter = 0;
            foreach (Person person in PrepareList.personList.personList)
            {
                if (username == PrepareList.personList.personList[i].Name && password == PrepareList.personList.personList[i].Password)
                {
                    if (PrepareList.personList.personList[i].Type == 1)
                    {
                        string studentID = PrepareList.personList.personList[i].PersonID();

                        Console.Clear();
                        StudentMenu(username, studentID);
                        counter++;
                    }
                    else if (PrepareList.personList.personList[i].Type == 2)
                    {
                        string employeeID = PrepareList.personList.personList[i].PersonID();

                        Console.Clear();
                        EmployeeMenu(username, employeeID);
                        counter++;
                    }
                }
                
                i++;
            }

            if (counter < 1)
            {
                Console.Clear();
                MenuScreen();
            }
        }

        static void StudentMenu(string name, string ID)
        {
            Console.Clear();
            StudentMainMenu.StudentMenuMain(name, ID);
            int menu = RegisterAcitvity.RegisterMenuInputMenu();

            if (menu == 1)
            {
                Console.Clear();
                StudentMainMenu.StudentMenuMain(name, ID);
                int activity = RegisterAcitvity.ChooseActivity();
                RegisterAcitvity.ActivityRegister(name, ID, activity);

                Console.Clear();
                StudentMenu(name, ID);

            }
            else if (menu == 2)
            {
                Console.Clear();
                StudentMainMenu.StudentMenuMain(name, ID);
                PrepareList.acitivityList.ShowRegisterActivity();
            }
            
        }

        static void EmployeeMenu(string name, string ID)
        {
            Console.Clear();
            EmployeeMainMenu.EmployeeMenuMain(name, ID);
            int menu = RegisterAcitvity.RegisterMenuInputMenu();

            if (menu == 1)
            {
                Console.Clear();
                EmployeeMainMenu.EmployeeMenuMain(name, ID);
                int activity = RegisterAcitvity.ChooseActivity();
                RegisterAcitvity.ActivityRegister(name, ID, activity);

                Console.Clear();
                EmployeeMenu(name, ID);

            }
            else if (menu == 2)
            {
                Console.Clear();
                EmployeeMainMenu.EmployeeMenuMain(name, ID);
                PrepareList.acitivityList.ShowRegisterActivity();
            }
        }

        static void RegisterMenu()
        {
            RegisterMenuHeader();
            RegisterMenuInput();
        }

        static void RegisterMenuHeader()
        {
            Console.WriteLine("Register Menu");
            Console.WriteLine("-------------");
        }

        static void RegisterMenuInput()
        {
            string name = InputInformation.InputName();
            string password = InputInformation.InputPassword();
            int type = InputInformation.InputType();

            if (type == 1)
            {
                string studentID = InputInformation.InputStudentID();

                Student student = CreatePerson.CreateNewStudent(name, password, type, studentID);
                PrepareList.personList.AddNewPerson(student);
                student.PersonID();

                Console.Clear();
                MenuScreen();
            }
            else if (type == 2)
            {
                string employeeID = InputInformation.InputEmployeeID();

                Employee employee = CreatePerson.CreateNewEmployee(name, password, type, employeeID);
                PrepareList.personList.AddNewPerson(employee);
                employee.PersonID();

                Console.Clear();
                MenuScreen();
            }
        }
    }

    class StudentMainMenu
    {
        public static void StudentMenuMain(string name, string ID)
        {
            StudentMenuHeader();
            StudentMenuShowNameID(name, ID);

        }

        public static void StudentMenuHeader()
        {
            Console.WriteLine("Student Menu");
            Console.WriteLine("------------");
        }

        public static void StudentMenuShowNameID(string name, string ID)
        {
            Console.WriteLine("Name: {0}", name);
            Console.WriteLine("Student ID: {0}", ID);
            Console.WriteLine("------------");
        }
    }

    class RegisterAcitvity
    {
        public static int RegisterMenuInputMenu()
        {
            Console.WriteLine("1. Register Activity");
            Console.WriteLine("2. Exit");
            Console.Write("Input Menu: ");
            int menu = int.Parse(Console.ReadLine());

            while (menu < 1 || menu > 2)
            {
                Console.Write("Input Menu: ");
                menu = int.Parse(Console.ReadLine());
            }

            return menu;
        }

        static void ActivityToChoose()
        {
            Console.WriteLine("1. Media Battleground");
            Console.WriteLine("2. Yu-Gi-Oh Battle Royale");
            Console.WriteLine("3. Dream Colored Patissier");
        }

        public static int ChooseActivity()
        {
            Console.WriteLine("Input The Number Of Activity To Register");
            ActivityToChoose();
            Console.Write("Input Number: ");
            int number = int.Parse(Console.ReadLine());

            ChooseActivityCheck(number);

            return number;
        }

        static void ChooseActivityCheck(int number)
        {
            while (number < 1 || number > 3)
            {
                Console.Write("Number Incorrect Input New Number: ");
                number = int.Parse(Console.ReadLine());
            }
        }

        public static void ActivityRegister(string name, string ID, int number)
        {
            if (number == 1)
            {
                MediaBattleground mediaBattleground = CreateRegisterActivity.RegisterMedia(name, ID);
                PrepareList.acitivityList.RegisterActivity(mediaBattleground);

            }
            else if (number == 2)
            {
                YuGiOhBattleRoyal yugiohBattleRoyal = CreateRegisterActivity.RegisterYGO(name, ID);
                PrepareList.acitivityList.RegisterActivity(yugiohBattleRoyal);

            }
            else if (number == 3)
            {
                DreamColoredPatissier dreamcolorPatissier = CreateRegisterActivity.RegisterPatissier(name, ID);
                PrepareList.acitivityList.RegisterActivity(dreamcolorPatissier);

            }
        }
    }

    class EmployeeMainMenu
    {
        public static void EmployeeMenuMain(string name, string ID)
        {
            EmployeeMenuHeader();
            EmployeeMenuShowNameID(name, ID);
        }
        static void EmployeeMenuHeader()
        {
            Console.WriteLine("Employee Menu");
            Console.WriteLine("-------------");
        }

        static void EmployeeMenuShowNameID(string name, string ID)
        {
            Console.WriteLine("Name: {0}", name);
            Console.WriteLine("Employee ID: {0}", ID);
            Console.WriteLine("-------------");
        }
    }

    class InputInformation
    {
        public static string InputName()
        {
            Console.Write("Input Name: ");
            return Console.ReadLine();
        }

        public static string InputPassword()
        {
            Console.Write("Input Password: ");
            return Console.ReadLine();
        }

        public static int InputType()
        {
            Console.Write("Input Type 1. Student, 2. Employee: ");
            int type = int.Parse(Console.ReadLine());
            while (type != 1 && type != 2)
            {
                Console.WriteLine("Wrong Number Please Input Again");
                type = int.Parse(Console.ReadLine());
            }

            return type;
        }

        public static string InputStudentID()
        {
            Console.Write("Input Your StudentID: ");
            return Console.ReadLine();
        }

        public static string InputEmployeeID()
        {
            Console.Write("Input Your EmployeeID: ");
            return Console.ReadLine();
        }
    }

    class CreatePerson
    {
        public static Student CreateNewStudent(string name, string password, int type, string studentID)
        {
            return new Student(name, password, type, studentID);
        }

        public static Employee CreateNewEmployee(string name, string password, int type, string employeeID)
        {
            return new Employee(name, password, type, employeeID);
        }

    }

    class CreateRegisterActivity
    {
        public static MediaBattleground RegisterMedia(string name, string ID)
        {
            return new MediaBattleground(name, ID);
        }

        public static YuGiOhBattleRoyal RegisterYGO(string name, string ID)
        {
            return new YuGiOhBattleRoyal(name, ID);
        }

        public static DreamColoredPatissier RegisterPatissier(string name, string ID)
        {
            return new DreamColoredPatissier(name, ID);
        }
    }

    class PrepareList
    {
        public static PersonList personList;

        public static void PreparePersonList()
        {
            personList = new PersonList();
        }

        public static AcitivityList acitivityList;

        public static void PrepareActivityList()
        {
            acitivityList = new AcitivityList();
        }

    }

    class Person
    {
        public string Name;
        public string Password;
        public int Type;
        public virtual string PersonID()
        {
            return "0";
        }

        public Person(string name, string password, int type)
        {
            this.Name = name;
            this.Password = password;
            this.Type = type;
        }
    }

    class Student: Person
    {
        public string StudentID;

        public Student(string name, string password, int type, string studentID) : base(name, password, type)
        {
            this.StudentID = studentID;
        }

        public override string PersonID()
        {
            return this.StudentID;
        }
    }

    class Employee: Person
    {
        public string EmployeeID;

        public Employee(string name, string password, int type, string employeeID) : base(name, password, type)
        {
            this.EmployeeID = employeeID;
        }

        public override string PersonID()
        {
            return this.EmployeeID;
        }
    }

    class PersonList
    {
        public List<Person> personList;
        public PersonList()
        {
            this.personList = new List<Person>();
        }

        public void AddNewPerson(Person newPerson)
        {
            this.personList.Add(newPerson);
        }
    }

    class Activity
    {
        public string Username;
        public string ID;

        public Activity(string username, string id)
        {
            this.Username = username;
            this.ID = id;
        }

        public string GetName()
        {
            return this.Username;
        }

        public string GetID()
        {
            return this.ID;
        }
    }

    class MediaBattleground: Activity
    {
        public MediaBattleground(string username, string id): base(username, id) { }

    }

    class YuGiOhBattleRoyal: Activity
    {
        public YuGiOhBattleRoyal(string username, string id) : base(username, id) { }

    }

    class DreamColoredPatissier: Activity
    {
        public DreamColoredPatissier(string username, string id) : base(username, id) { }

    }

    class AcitivityList
    {
        public List<Activity> activityList;

        public AcitivityList()
        {
            this.activityList = new List<Activity>();
        }

        public void RegisterActivity(Activity newActivity)
        {
            this.activityList.Add(newActivity);
        }

        public void ShowRegisterActivity()
        {
            int counter = 0;
            Console.WriteLine("Registered Acitivity");
            Console.WriteLine("-------------------");
            foreach (Activity activity in this.activityList)
            {
                if(activity is MediaBattleground)
                {
                    Console.WriteLine("Media Battleground - Name: {0} ID: {1}", activity.GetName(), activity.GetID());
                    counter++;
                }
                else if (activity is YuGiOhBattleRoyal)
                {
                    Console.WriteLine("Yu-Gi-Oh Battle Royale - Name: {0} ID: {1}", activity.GetName(), activity.GetID());
                    counter++;
                }
                else if (activity is DreamColoredPatissier)
                {
                    Console.WriteLine("Dream Colored Patissier - Name: {0} ID: {1}", activity.GetName(), activity.GetID());
                    counter++;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("None Activity Has Registered");
            }
        }

    }

}