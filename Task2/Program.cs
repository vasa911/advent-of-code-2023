using var reader = new StreamReader("input.txt");
var content = reader.ReadToEnd()
    .Split(Environment.NewLine);
var sum = CalculateSum(content);

Console.WriteLine(sum);

public partial class Program
{
    public static List<(string, int)> Numbers = new List<(string, int)>()
    {
    ("one", 1 ),
    ("two", 2 ),
    ("three", 3 ),
    ("four", 4 ),
    ("five", 5 ),
    ("six", 6 ),
    ("seven", 7 ),
    ("eight", 8 ),
    ("nine", 9 ),
    };


    public static int CalculateSum(string[] content)
    {
        var processed = content
           .Select(MapCharacterToNumbers)
            .Where(i => !string.IsNullOrWhiteSpace(i))
            .ToArray();

        int sum = 0;

        foreach (var line in processed)
        {
            int number = ExtractNumberFromLine(line);
            sum += number;
        }

        return sum;
    }

    public static int ExtractNumberFromLine(string line)
    {
        int number = 0;
        if (line.Count() == 1)
        {
            number = int.Parse(line[0].ToString() + line[0].ToString());
        }
        else
        {
            number = int.Parse(line[0].ToString() + line[line.Length - 1].ToString());
        }

        return number;
    }

    public static string MapCharacterToNumbers(string line)
    {
        string processedChars = "";
        string leftNumber = "";
        for (int i = 0; i < line.Length;i++)
        {
            processedChars += line[i].ToString();
            leftNumber = GetNumber(line[i], processedChars);
            if (!string.IsNullOrEmpty(leftNumber))
            {
                break;
            }
        }

        processedChars = "";
        string rightNumber = "";
        for(int i = line.Length - 1; i >= 0; i--)
        {
            processedChars += line[i].ToString();
            var charArray = processedChars.ToCharArray();
            Array.Reverse(charArray);
            var reversed = new string(charArray);
            rightNumber = GetNumber(line[i], reversed);
            if (!string.IsNullOrEmpty(rightNumber))
            {
                break;
            }
        }

        return leftNumber+rightNumber;
    }

    private static string GetNumber(char currentChar, string processedChars)
    {
        string result = "";
        if (char.IsDigit(currentChar))
        {
            result += currentChar.ToString();
        }
        else
        {
            foreach (var num in Numbers)
            {
                if (processedChars.Contains(num.Item1))
                {
                    result += num.Item2;
                }
            }


        }
        return result;
    } 
}