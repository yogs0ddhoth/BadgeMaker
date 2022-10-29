namespace CatWorx.BadgeMaker
{
    class Util
    {
        public static void PrintEmployees(List<Employee> employees)
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
    }
}