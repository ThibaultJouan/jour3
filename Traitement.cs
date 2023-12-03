using System.Text.RegularExpressions;

class Traitement
{
    public string[] Input {get; set;}

    public Traitement(string[] input)
    {
        Input = input;
    }
    public int Part2()
    {
        Regex regexSym = new Regex(@"\*");
        int result = 0;

        for(int i = 0; i < Input.Length; i++)
        {
            IEnumerable<Match> matchSym = regexSym.Matches(Input[i]);

            foreach(Match m in matchSym)
            {
                int buffer = SumOfNumbersAround(i, m.Index);
                if(buffer != 0)
                {
                    result += buffer; 
                }
            }
        }
        return result;
    }

    public int Part1()
    {
        Regex regex = new Regex(@"\d+");
        int result = 0;

        for(int i = 0; i < Input.Length; i++)
        {
            IEnumerable<Match> match = regex.Matches(Input[i]);

            foreach(Match m in match)
            {
                if(HasAnythingAround(i, m.Index, m.Length))
                {
                    result += int.Parse(m.Value);
                }
            }

        }

        return result;
    }

    public int SumOfNumbersAround(int x, int y)
    {
        Regex regexNum = new Regex(@"\d+");
        int numbersAround = 0;
        int sum = 1;

        int fromY = 0;
        int toY = 0;
        int fromX = 0;
        int toX = 0;

        if(x == 0)
        {
            fromX = 0;
        }
        else
        {
            fromX = x-1;
        }
        if(y == 0)
        {
            fromY = 0;
        }
        else
        {
            fromY = y-1;
        }
        if(x == Input[x].Length - 1)
        {
            toX = Input[x].Length - 1;
        }
        else
        {
            toX = x+1;
        }
        if(y + 1 >= Input.Length - 1)
        {
            toY = Input.Length - 1;
        }
        else
        {
            toY = y+1;
        }

        for(int i = fromX; i <= toX; i++)
        {
            string work = Input[i];
                foreach(Match m in regexNum.Matches(work))
                {
                    if(Math.Abs(m.Index - y) <= 1 || Math.Abs(m.Index + m.Length -1 - y) <= 1)
                    {
                        sum *= int.Parse(m.Value);
                        numbersAround ++;
                        Console.WriteLine(m.Value);
                    }
                }
        }
        if(numbersAround > 1)
        {
            Console.WriteLine("OOOOOOK");
            return sum;
        }
        Console.WriteLine("NOOOOOOOOOOOOOOOOOOOOPE");
        return 0;
    }

    public bool HasAnythingAround(int x, int y, int length)
    {
        string symbols = "!@#$%^&*()_+=-/";
        int fromY = 0;
        int toY = 0;
        int fromX = 0;
        int toX = 0;

        if(x == 0)
        {
            fromX = 0;
        }
        else
        {
            fromX = x-1;
        }
        if(y == 0)
        {
            fromY = 0;
        }
        else
        {
            fromY = y-1;
        }
        if(x == Input[x].Length - 1)
        {
            toX = Input[x].Length - 1;
        }
        else
        {
            toX = x+1;
        }
        if(y + length >= Input.Length - 1)
        {
            toY = Input.Length - 1;
        }
        else
        {
            toY = y+length;
        }



        for(int i = fromX; i <= toX; i++)
        {
            string work = Input[i];
            for(int j = fromY; j <= toY; j++)
            {
                if(symbols.Contains(work[j]))
                {
                    return true;
                }
            }
        }
        return false;
    }
}