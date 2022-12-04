struct Pair
{
    public Assignment[] assignments;
}
struct Assignment
{
    public int[] bounds;
}
internal class Program
{
    static string[] rows = File.ReadAllLines("input.txt");
    private static void Main(string[] args)
    {
        part1();
        part2();
    }
    static void part1()
    {
        Pair[] pairs = new Pair[rows.Length];//array cointaining all the pairs
        Pair tmpPair;
        string[] pairstring;
        int[] assignmentstring;
        int sum = 0;
        for (int i = 0; i < pairs.Length; i++)
        {
            pairstring = rows[i].Split(',');//split he pair in two assignments
            tmpPair.assignments = new Assignment[2];
            for (int j = 0; j < tmpPair.assignments.Length; j++)
            {
                assignmentstring = (from b in pairstring[j].Split('-')
                                    select int.Parse(b)).ToArray();//split the assignment in 2 bounds
                tmpPair.assignments[j].bounds = new int[2];
                for (int l = 0; l < assignmentstring.Length; l++)
                {
                    tmpPair.assignments[j].bounds[l] = assignmentstring[l];
                }//assign the bounds to the array
            }
            pairs[i] = tmpPair;//add the pair to the array
            if (overlap(pairs[i]))
                sum++;
            StreamWriter sw = new StreamWriter("output.txt");
            sw.WriteLine(sum);//write the output
            sw.Close();//close the file
        }
    }
    static void part2()
    {
        Pair[] pairs = new Pair[rows.Length];//array cointaining all the pairs
        Pair tmpPair;
        string[] pairstring;
        int[] assignmentstring;
        int sum = 0;
        for (int i = 0; i < pairs.Length; i++)
        {
            pairstring = rows[i].Split(',');//split he pair in two assignments
            tmpPair.assignments = new Assignment[2];
            for (int j = 0; j < tmpPair.assignments.Length; j++)
            {
                assignmentstring = (from b in pairstring[j].Split('-')
                                    select int.Parse(b)).ToArray();//split the assignment in 2 bounds
                tmpPair.assignments[j].bounds = new int[2];
                for (int l = 0; l < assignmentstring.Length; l++)
                {
                    tmpPair.assignments[j].bounds[l] = assignmentstring[l];
                }//assign the bounds to the array
            }
            pairs[i] = tmpPair;//add the pair to the array
            if (nooverlapatall(pairs[i]))
                sum++;
            StreamWriter sw = new StreamWriter("output.txt");
            //subtract pairs that don't overlap at all from the total number of pairs
            sw.WriteLine(pairs.Length - sum);//write the output
            sw.Close();//close the file
        }
    }
    static bool overlap(Pair p)
    {//calculates if one assignment of the given pair is fully contained in the other one
        return ((p.assignments[0].bounds[0] >= p.assignments[1].bounds[0])//if the first bound of the first assignment is greater than or equal to the first bound of the second assignment
        && (p.assignments[0].bounds[1] <= p.assignments[1].bounds[1]))//and the second bound of the first assignment is less than or equal to the second bound of the second assignment
        //so, if the first assignment is fully contained in the second one
        ||//or
        ((p.assignments[1].bounds[0] >= p.assignments[0].bounds[0])//if the first bound of the second assignment is greater than or equal to the first bound of the first assignment
        && (p.assignments[1].bounds[1] <= p.assignments[0].bounds[1]));//and the second bound of the second assignment is less than or equal to the second bound of the first assignment
        //so, if the second assignment is fully contained in the first one
    }
    static bool nooverlapatall(Pair p)
    {//calculates if one assignment of the given pair doesn't overlap at all with the other one
        return (((p.assignments[0].bounds[1] < p.assignments[1].bounds[0])//if the second bound of the first assignment is less than the first bound of the second assignment
        || (p.assignments[0].bounds[0] > p.assignments[1].bounds[1]))//or the first bound of the first assignment is grater than the second bound of the second assignment
        //so, if the first assignment bounds are totally outside the second assignment bounds
        &&
        ((p.assignments[1].bounds[1] < p.assignments[0].bounds[0])//if the second bound of the second assignment is less than the first bound of the first assignment
        || (p.assignments[1].bounds[0] > p.assignments[0].bounds[1])));//or the first bound of the second assignment is grater than the second bound of the first assignment;
        //so, if the second assignment bounds are totally outside the first assignment bounds
    }
}