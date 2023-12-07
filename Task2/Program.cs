﻿using System.Text.RegularExpressions;

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
        foreach (var charInLine in line)
        {
            processedChars += charInLine;
            Numbers.ForEach(num => { processedChars = processedChars.Replace(num.Item1, num.Item2.ToString()); });
        }
        processedChars = Regex.Replace(processedChars, @"[^\d]", "");
        return processedChars;
    }
}