using System.Text;

class Program
{
    public static string ConcatenateStrings(string str1, string str2) => string.Concat(str1, str2); //1
    public static string GreetUser(string name, int age) => $"Hello, {name}!\nYou are {age} years old."; //2
    public static string Modify(string str) => $"Symbols: {str.Length};\nUpper: {str.ToUpper()};\nLower: {str.ToLower()}."; //3
    public static string First5(string str) => str.Substring(0, 5); //4
    public static StringBuilder BuildFromStrings(string[] strs) //5
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendJoin(' ', strs); //I guess, neither Append, nor AppendLine:)
        return builder;
    }
    public static string ReplaceWords(string inputString, string wordToReplace, string replacementWord) => //6
        inputString.Replace(wordToReplace, replacementWord);

    static void Main(string[] args) 
    {
        //1
        Assert.AreEqual("This is str1, this is str2",
                        ConcatenateStrings("This is str1, ", "this is str2"),
                        "1_1 failed");
        Assert.AreEqual("This is str1, other one is empty",
                        ConcatenateStrings("This is str1, other one is empty", ""),
                        "1_2 failed");
        //2
        Assert.AreEqual("Hello, Egor!\nYou are 58 years old.", 
                        GreetUser("Egor", 58),
                        "2 failed");
        //3
        Assert.AreEqual($"Symbols: 21;\nUpper: Я ВЫНУЛ ИЗ ГОЛОВЫ ШАР;\nLower: я вынул из головы шар.",
                        Modify("Я вынул из головы шар"),
                        "3 failed");
        //4
        Assert.AreEqual("Some ",
                        First5("Some words"),
                        "4 failed");
        //5
        Assert.AreEqual("Something, something, bla-bla-bla",
                        BuildFromStrings(["Something,", "something,", "bla-bla-bla"]).ToString(),
                        "5 failed");
        //6
        Assert.AreEqual("дважды два равно четыре",
                        ReplaceWords("трижды три равно четыре", "три", "два"),
                        "6 failed");

        Console.WriteLine("Всё прошло успешно!");
    }
}