namespace CatWorx.BadgeMaker
{
  class Program
  {
    async static Task Main(string[] args)
    {
        List<Employee> employees = await PeopleFetcher.GetEmployees();
        Util.PrintEmployees(employees);
        Util.WriteCSV(employees);
        await Util.MakeBadges(employees);

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