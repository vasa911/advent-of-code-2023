using System.Text.RegularExpressions;


var numbers = new List<(string, int)>()
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


using var reader = new StreamReader("input.txt");
var content = reader.ReadToEnd()
    .Split(Environment.NewLine)
    .Select(line =>
    {
        string processedChars = "";
        foreach (var charInLine in line)
        {
            processedChars += charInLine;
            numbers.ForEach(num => { processedChars = processedChars.Replace(num.Item1, num.Item2.ToString()); });
        }
        return processedChars;
    })
    .Select(i => Regex.Replace(i, @"[^\d]", ""))
    .Where(i => !string.IsNullOrWhiteSpace(i)).ToArray();
int sum = 0;

foreach (var line in content)
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
    sum += number;
}

Console.WriteLine(sum);
