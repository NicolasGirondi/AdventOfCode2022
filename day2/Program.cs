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
        string s = sr.ReadToEnd();//read the content of the file
        sr.Close();//close the file
        string[] rows = s.Split('\n');//split the content in rows
        int tot = 0;
        foreach (var r in rows)//for each row
        {
            tot += roundscore(r[0], r[2]);//pass the 2 shapes to the function
        }
        StreamWriter sw = new StreamWriter("output.txt");
        sw.WriteLine(tot);//write the output
        sw.Close();//close the file
    }
    static void part2()
    {
        StreamReader sr = new StreamReader("input.txt");
        string s = sr.ReadToEnd();//read the content of the file
        sr.Close();//close the file
        string[] rows = s.Split('\n');//split the content in rows
        int tot = 0;
        foreach (var r in rows)//for each row
        {
            tot += predictedscore(r[0], r[2]);//pass the elf shape and the predicted result to the function
        }
        StreamWriter sw = new StreamWriter("output.txt");
        sw.WriteLine(tot);//write the output
        sw.Close();//close the file
    }
    static int roundscore(char elfshape, char selectedshape)
    {//calculates who wins the round and returns winner's sum
        int sum = 0;
        if (selectedshape == 'X')//if user selected rock
        {
            sum++;//add 1 because user selected rock
            if (elfshape == 'A')//draw
                sum += 3;
            else if (elfshape == 'C')//win
                sum += 6;
        }
        else if (selectedshape == 'Y')//if user selected paper
        {
            sum += 2;//add 2 because user selected paper
            if (elfshape == 'A')//win
                sum += 6;
            else if (elfshape == 'B')//draw
                sum += 3;
        }
        else//if user selected scissors
        {
            sum += 3;//add 3 because user selected scissors
            if (elfshape == 'B')//win
                sum += 6;
            else if (elfshape == 'C')//draw
                sum += 3;
        }//in case of loss, add only the points referring to the shape
        return sum;
    }
    static int predictedscore(char elfshape, char outcome)
    {//calculates wich shape will make the user get the predicted outcome and calculates score
        int sum = 0;
        if (outcome == 'X')//loss
        {
            //no points
            if (elfshape == 'A')//elf selected rock, so to lose user has to select scissors
                sum += 3;
            else if (elfshape == 'B')//elf selected paper, so to lose user has to select rock
                sum++;
            else//elf selected scissors, so to lose user has to select paper
                sum += 2;
        }
        else if (outcome == 'Y')//draw
        {
            sum += 3;//add 3 outcome points
            //now just select the same shape of the elf
            if (elfshape == 'A')
                sum++;
            else if(elfshape == 'B')
                sum+=2;
            else
                sum+=3;
        }
        else//win
        {
            sum+=6;//add 6 outcome points
            if(elfshape == 'A')//elf selected rock, so to win user has to select paper
                sum+=2;
            else if(elfshape == 'B')//elf selected paper, so to win user has to select scissors
                sum+=3;
            else//elf selected scissors, so to win user has to select rock
                sum++; 
        }
        return sum;
    }
}