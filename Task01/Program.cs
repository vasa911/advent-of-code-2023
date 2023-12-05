using System.Text.RegularExpressions;

using var reader = new StreamReader("input.txt");
var content = reader.ReadToEnd().Split(Environment.NewLine).Select(i=> Regex.Replace(i, @"[^\d]", "")).Where(i=>!string.IsNullOrWhiteSpace(i)).ToArray();
int sum = 0;

foreach (var line in content)
{
    int number = 0;
    if (line.Count() == 1)
    {
         number = int.Parse(line[0].ToString()+ line[0].ToString());
    }
    else
    {
         number = int.Parse(line[0].ToString() + line[line.Length-1].ToString());
    }
    sum+=number;
}

Console.WriteLine(sum);
