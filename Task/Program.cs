
using System;
using System.Xml.Linq;

namespace Task
{
    class Program
    {
        private static void WriteInstruction() => Console.WriteLine("Type '-exit' to exit the task"); //fast instruction
        private static string ReadLineWithCheck() //read while checking for exit
        {
            string str = Console.ReadLine();
            if (str == "-exit")
                Environment.Exit(0);
            return str;
        }

        private static int GetIntForSure(int min = int.MinValue, int max = int.MaxValue) //number check
        {
            int num = 0;
            while (ReadLineWithCheck() is string str && (!int.TryParse(str, out num) || num > max || num < min))
                Console.WriteLine("Not a valid number!");
            return num;
        }

        private abstract class Task
        {
            public abstract void TaskLoop(); //the prettiest solution
        }

        private class ListTask : Task
        {
            public override void TaskLoop()
            {
                WriteInstruction();
                List<string> list = new() { "Roses are red",
                                    "Violets are blue",
                                    "Some poems rhyme,",
                                    "But this one doesn't."}; //Создайте список строк (List) и добавьте в него несколько элементов.
                while (true)
                {
                    Console.WriteLine("Write something:");
                    list.Add(ReadLineWithCheck()); //Затем попросите пользователя ввести новую строку и добавьте ее в список.
                    Console.WriteLine("Now list looks like this:");
                    foreach (var item in list)
                        Console.WriteLine(item); //Выведите содержимое списка на экран.
                    Console.WriteLine("Write something again:");
                    list.Insert(list.Count / 2, ReadLineWithCheck()); //Попросите пользователя ввести ещё одну строку, и добавьте её в середину списка
                }
            }
        }

        private class DictionaryTask : Task
        {
            public override void TaskLoop()
            {
                WriteInstruction();
                Dictionary<string, int> dict = new();
                string name;
                while (true)
                {
                    Console.WriteLine("Write the name:");
                    name = ReadLineWithCheck();
                    Console.WriteLine("Write the mark:"); //Попросите пользователя ввести имя студента и его оценку. 
                    dict.Add(name, GetIntForSure(2, 5)); //right mark
                    Console.WriteLine("Write the name to search for:");
                    name = ReadLineWithCheck();
                    if (dict.TryGetValue(name, out int mark)) //Затем попросите пользователя ввести имя студента, и выведите оценку.
                        Console.WriteLine("Their mark is " + mark + ".");
                    else //Если студента нет в словаре, напишите, что студента с таким именем не существует.
                        Console.WriteLine("This student doesn't exist.");
                }
            }
        }
        private class LinkedListTask : Task
        {
            public override void TaskLoop()
            {
                WriteInstruction();
                int elemNum;
                while (true)
                {
                    TwoSidedNode firstNode = null; //let's do it simple way
                    TwoSidedNode lastNode = null;
                    Console.WriteLine("Choose the number of elements (3-6):"); 
                    elemNum = GetIntForSure(3, 6); //Предложите пользователю создать список, ввести от 3 до 6 элементов 
                    Console.WriteLine("Now start entering:");
                    for (int i = 0; i < elemNum; i++) {
                        lastNode = new TwoSidedNode(GetIntForSure());
                        if (firstNode == null)
                            firstNode = lastNode;
                        else
                            firstNode.AddLast(lastNode);
                    }
                    Console.Write("Your list: ");
                    firstNode.Print();
                    Console.WriteLine("Your list backwards: ");
                    lastNode.PrintBackwards(); //затем вывести список в прямом и обратном порядках.

                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Choose the task (1-3):");
            int taskNum = 0;
            while (Console.ReadLine() is string str && (!int.TryParse(str, out taskNum) || taskNum > 3 || taskNum < 1))
                Console.WriteLine("Not a valid number!"); //we don't have an exit option outside of loops
            switch (taskNum)
            {
                case 1:
                    CheckTask(new ListTask());
                    break;
                case 2:
                    CheckTask(new DictionaryTask());
                    break;
                case 3:
                    CheckTask(new LinkedListTask());
                    break;
                default:
                    Console.WriteLine("SOMETHING IS DEEPLY WRONG");
                    break;
            }
        }

        private static void CheckTask(Task task) => task.TaskLoop();
    }
}