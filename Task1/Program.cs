using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the first number:");
        if (!int.TryParse(Console.ReadLine(), out int first))
        {
            Console.WriteLine("Not a number:(");
            return;
        }
        Console.WriteLine("Enter the second number:");
        if (!int.TryParse(Console.ReadLine(), out int sercond))
        {
            Console.WriteLine("Not a number:(");
            return;
        }
        Console.WriteLine("Enter the operation:");
        var operation = Console.ReadLine();
        if (operation?.Length != 1)
        {
            Console.WriteLine("Not a single character:(");
            return;
        }
        int result = 0;
        switch (operation[0])
        {
            case '&':
                result = first & sercond;
                break;
            case '|':
                result = first | sercond;
                break;
            case '^':
                result = first ^ sercond;
                break;
            default:
                Console.WriteLine("Operation is not supported:(");
                return;
        }
        Console.WriteLine("Result of {0} {1} {2} = ", first, sercond, operation[0]);
        Console.WriteLine("{0} in decimal form;", result);
        Console.WriteLine("{0} in binary form;", Convert.ToString(result, 2));
        Console.WriteLine("{0} in hexadecimal form.", Convert.ToString(result, 16));
    }
}