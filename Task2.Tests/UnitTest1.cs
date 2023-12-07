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
        [TestCase("two1nine", "219")]
        [TestCase("eightwothree", "83")]
        [TestCase("abcone2threexyz", "123")]
        [TestCase("xtwone3four", "234")]
        [TestCase("nineeightseven2", "9872")]
        [TestCase("zoneight234", "1234")]
        [TestCase("pqrstsixteen", "6")] 
        [TestCase("pjb92two5sevenfkb6three", "9225763")]
        [TestCase("onetwothreefourfivesixseveneightnine", "123456789")] 
        [TestCase("dxbxkzmpzzthreestcvtvhftgzctnvnshzgqtbgxlrqkthreefgxdrfmm7", "337")]
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