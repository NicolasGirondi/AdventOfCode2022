internal class Program
{
    private static void Main(string[] args)
    {
        part1();
        part2();
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
    static void part2()
    {
        StreamReader sr = new StreamReader("input.txt");
        string s = sr.ReadToEnd();//read all the file
        sr.Close();//close the file
        string[] rucksacks = s.Split('\n');//split the rows in rucksacks
        string[] elfgroup = new string[3];//every group is composed of 3 elves
        int sum = 0;
        for (int i = 0; i < rucksacks.Length / 3; i++)//for every elfgroup
        {
            for (int j = 0; j < elfgroup.Length; j++)//for every elf of the group
            {
                elfgroup[j] = rucksacks[3 * i + j];//fill the group with the rucksacks
            }
            sum += grouppriority(elfgroup);
        }
        StreamWriter sw = new StreamWriter("output.txt");
        sw.WriteLine(sum);//write the output
        sw.Close();//close the file
    }
    static int rucksackpriority(string[] compartments)
    {//calculates what item type is in both the compartments and returns the item priority
        int res = 0, i = 0;
        bool found = false;
        do//while no item is repeated in the compartments and the compartment is not completely checked
        {
            found = compartments[1].Contains(compartments[0][i]);//search if the item ot this compartment is in the other compartment
            if (found)
                res = itempriority(compartments[0][i]);
            //result = (from 1 through 26 for letters from 'a' through 'z', from 27 to 52 for letters from 'A' to 'Z')
            i++;
        } while (!found && i < compartments[0].Length);
        return res;
    }
    static int grouppriority(string[] elfgroup)
    {//calculates what item type is in all the three groups and returns the item priority
        int res = 0, i = 0;
        bool found = false;
        do//while no item is repeated in the three groups
        {   //find the item that is in all the 3 group rucksacks
            found = elfgroup[1].Contains(elfgroup[0][i]) && elfgroup[2].Contains(elfgroup[0][i]);
            if (found)
                res = itempriority(elfgroup[0][i]);//calculate the priority of the repeated item
            i++;
        } while (!found && i < elfgroup[0].Length);
        return res;
    }
    static int itempriority(char item)
    {
        return (item >= 'A' && item <= 'Z') ? item - 38 : item - 96;
    }
}