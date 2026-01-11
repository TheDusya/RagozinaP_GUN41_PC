internal class Program
{
    static void Main(string[] args)
    {
        // Здесь массивы заданий 1-4
        //Задание 1
        int[] fibonacci = { 0, 1, 1, 2, 3, 5, 8, 13 };

        //Задание 2
        string[] months =  {"January", "February",
                        "March", "April", "May",
                        "June", "July", "August",
                        "September", "October", "November",
                        "December"};

        //Задание 3
        int[,] powMatrix = new int[3, 3];
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                powMatrix[i, j] = (int)Math.Pow((j + 2), (i + 1));

        //Задание 4
        double[][] jagged = new double[3][] {
            new double[5] {1, 2, 3, 4, 5},
            new double[2] {Math.E, Math.PI},
            new double[4] {Math.Log10(1), Math.Log10(10), Math.Log10(100), Math.Log10(1000)}
        };      //Math.Log(1000, 10) даёт неточный результат из-за округления

        // массивы для заданий 5 и 6.
        int[] array = { 1, 2, 3, 4, 5 };
        int[] array2 = { 7, 8, 9, 10, 11, 12, 13 };
        Array.Copy(array, array2, 3);
        Console.WriteLine(array2);
        Array.Resize(ref array, array.Length * 2);
    }
}