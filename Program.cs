﻿namespace CatWorx.BadgeMaker
{
  class Program
  {
    static List<Employee> GetEmployees()
    {
        List<Employee> employees = new List<Employee>();

        while (true) 
        {
            Console.WriteLine("Enter first name: (leave empty to exit): ");

            string firstName = 
                Console.ReadLine() // read the next line of characters in the input stream
                ?? "";             // null coalescing operator catches null values and replace with the following value  
            if (firstName == "")
            {
                break;
            }

            Console.WriteLine("Enter last name: ");
            string lastName = Console.ReadLine() ?? "";

            Console.WriteLine("Enter ID: ");
            int id = Int32.Parse(Console.ReadLine() ?? "");

            Console.WriteLine("Enter Photo URL: ");
            string photoUrl = Console.ReadLine() ?? "";

            Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
            employees.Add(currentEmployee);
        }

        return employees;
    }
    static void PrintEmployees(List<Employee> employees)
    {
        Console.WriteLine("Employees:");

        int count = employees.Count;
        for (int i = 0; i < count; i++) 
        {
            string template = "{0, -10}\t{1, -20}\t{2}";
            Console.WriteLine(
                String.Format(
                    template, 
                    employees[i].GetId(), 
                    employees[i].GetFullName(), 
                    employees[i].GetPhotoUrl())
            );
        }
    }

    static void Main(string[] args)
    {
        List<Employee> employees = GetEmployees();
        PrintEmployees(employees);
    }

    void HelloWorld() 
    {
        string stringNum = "2";
        int num = Convert.ToInt32(stringNum);

        Console.WriteLine($"Hiya Chuck. {stringNum} is type: " + "{0}", num.GetType());

        Dictionary<string, int[]> loremIpsum = new Dictionary<string, int[]>() {
            {"lorem", new int[1] {1}},
            {"ipsum", new int[2] {2, 3}},
        };
        loremIpsum.Add("dolor", new int[3] {4, 5, 6});

        List<Dictionary<string, int[]>> oremLipsum = new List<Dictionary<string, int[]>>() {
            new Dictionary<string, int[]>() {
                {"sit amet", new int[1] {7}}
            }
        };
        oremLipsum.Add(loremIpsum);


        Console.WriteLine(
            "{0}, {1}, {2}, {3}, {4}, {5}, {6}", 
            oremLipsum[1]["lorem"][0], 
            oremLipsum[1]["ipsum"][0],
            oremLipsum[1]["ipsum"][1],
            oremLipsum[1]["dolor"][0],
            oremLipsum[1]["dolor"][1],
            oremLipsum[1]["dolor"][2],
            oremLipsum[0]["sit amet"][0]);
    }
  }
}