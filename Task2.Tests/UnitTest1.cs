namespace Task2.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("2", 22)]
        [TestCase("21", 21)]
        [TestCase("45345435435", 45)]
        public void ExtractNumberFromLine_CorrectValue_CorrectResult(string line, int expected)
        {
            var actual = Program.ExtractNumberFromLine(line);
            Assert.True(expected == actual);
        }




        [Test]
        [TestCase("two1nine", "29")]
        [TestCase("eightwothree", "83")]
        [TestCase("abcone2threexyz", "13")]
        [TestCase("xtwone3four", "24")]
        [TestCase("nineeightseven2", "92")]
        [TestCase("zoneight234", "14")]
        [TestCase("pqrstsixteen", "66")] 
        [TestCase("pjb92two5sevenfkb6three", "93")]
        [TestCase("onetwothreefourfivesixseveneightnine", "19")] 
        [TestCase("dxbxkzmpzzthreestcvtvhftgzctnvnshzgqtbgxlrqkthreefgxdrfmm7", "37")]
        public void MapCharacterToNumbers_CorrectValue_CorrectResult(string input, string expected)
        {
            var actual = Program.MapCharacterToNumbers(input);
            Assert.True(expected == actual);
        }

        [Test]
        [TestCase(new[]
        {
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen",
        }, 281)]
        [TestCase(new[]
        {
            "bfivehtndrmm62",
            "829fourbjpmbfqkqgsixtwo",
            "xvcdsix3five",
            "sixhqthreeninethree7",
            "gpsdvj3zpztgcndvcxz12",
            "seven3fglvdzxzcqfive7four9five",
            "3five4gzgjbpptwo",
            "nine44four8",
            "4143two",
            "fourpcjhfjrxdhvzf2dkmszvtjx"
        }, 587)]
        public void CalculateSum(string[] input, int expected)
        {
            var actual = Program.CalculateSum(input);
            Assert.True(expected == actual);
        }
    }
}