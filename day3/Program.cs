internal class Program
{
    private static void Main(string[] args)
    {
        part1();
    }
    static void part1()
    {
        StreamReader sr = new StreamReader("input.txt");
        string s = sr.ReadToEnd();//read all the file
        sr.Close();//close the file
        string[] rucksacks = s.Split('\n');//split the rows in rucksacks
        string[] compartments;
        int sum = 0;
        foreach (var r in rucksacks)//for each rucksack
        {
            compartments = new string[] { r.Substring(0, r.Length / 2), r.Substring(r.Length / 2) };//split the rucksack in 2 compartments
            sum += rucksackpriority(compartments);//calculate the rucksack priority
        }
        StreamWriter sw = new StreamWriter("output.txt");
        sw.WriteLine(sum);//write the output
        sw.Close();//close the file
    }
    static int rucksackpriority(string[] compartmets)
    {//calculates what item type is in both the compartments and returns the item priority
        int res = 0, i = 0;
        bool found = false;
        do//while no item is repeated in the compartments and the compartment is not completely checked
        {
            found = compartmets[1].Contains(compartmets[0][i]);//search if the item ot this compartment is in the other compartment
            if (found)
                res = (compartmets[0][i] >= 'A' && compartmets[0][i] <= 'Z') ? compartmets[0][i] - 38 : compartmets[0][i] - 96;
            //result = (from 1 through 26 for letters from 'A' to 'Z', from 27 through 52 for letters from 'a' through 'z')
            i++;
        } while (!found && i < compartmets[0].Length);
        return res;
    }
}