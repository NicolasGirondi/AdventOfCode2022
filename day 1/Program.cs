internal class Program
{
    private static void Main(string[] args)
    {
        part1();
        part2();
    }
    static void part1()
    {
        StreamReader sr = new StreamReader("input.txt");//read the file
        string s = sr.ReadToEnd();
        sr.Close();
        string[] rows = s.Split('\n');//divide rows
        int sum = 0, max = 0;
        foreach (var r in rows)
        {
            if (string.IsNullOrEmpty(r))//if the row is empty, we change elf
            {
                if (sum > max)
                    max = sum;//select the elf with the highest sum of calories
                sum = 0;
            }
            else
                sum += int.Parse(r);//add integer to the sum
        }
        StreamWriter sw = new StreamWriter("output.txt");//write the output
        sw.WriteLine(max);
        sw.Close();
    }
    static void part2()
    {
        int[] leaderboard = new int[3];//top three elves by calories
        List<int> sums = new List<int>();
        StreamReader sr = new StreamReader("input.txt");//read the file
        string s = sr.ReadToEnd();
        sr.Close();
        string[] rows = s.Split('\n');//divide rows
        int sum = 0;
        foreach (var r in rows)
        {
            if (string.IsNullOrEmpty(r))
            {
                sums.Add(sum);//add the sum to the list
                sum = 0;
            }

            else
                sum += int.Parse(r);//sum all the rows
        }
        StreamWriter sw = new StreamWriter("output.txt");//write the output
        sums.Sort();
        Console.WriteLine(sums.GetRange(0,3).Sum());//print the sum of the first three elves
        sw.Close();
    }
}