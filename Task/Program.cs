class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("FIBONACCI SEQUENCE:");
        int curr = 0;
        int next = 1;
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(curr);
            int temp = next;
            next = curr + next;
            curr = temp;
        }

        Console.WriteLine("\nODD NUMBERS:");
        for (int i = 2; i <= 20; i += 2)
            Console.WriteLine(i);

        Console.WriteLine("\nMULTIPLICATION TABLE:");
        for (int i = 1; i <= 5; i++)
        {
            for (int j = 1; j <= 5; j++)
                Console.Write($"{j*i}".PadLeft(3, ' '));
            Console.WriteLine();
        }

        Console.WriteLine("\nPASSWORD:");
        string password = "qwerty";
        do
            Console.WriteLine("Enter the password:");
        while (password != Console.ReadLine());
        Console.WriteLine("This one is right!");
    }
}