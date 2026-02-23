namespace Task.Dungeon
{
    public class DungeonRoom
    {
        //В текстовом ТЗ написано "В каждой комнате- лут, монстр или ничего",
        //а в презентации и в видео требуется иметь сразу поля Unit и Item и запечатанный класс.
        //Возникло ощущение, что лучше было бы иметь разные типы комнат.
        //Кажется, комнаты с тем и другим сразу не предусмотрены.
        //Скажите, пожалуйста, если я ошиблась.

        public readonly string Name;
        public readonly Dictionary<Direction, DungeonRoom> Rooms = new();
        public bool IsFinal => Rooms.Count == 0;
        public DungeonRoom(string name) => Name = name;
        
        public virtual void WriteIntro() => Console.WriteLine($"You enter the empty room - {Name}.");

        public void WriteInstructions()
        {
            if (IsFinal)
                Console.WriteLine("You have reached the end!");
            else
            {
                Console.WriteLine($"You can go:");
                foreach (Direction direction in Rooms.Keys)
                    Console.WriteLine($"{direction}({(int)direction})");
            }
        }

        public bool TrySetDirection(Direction direction, DungeonRoom room)
        {
            if (Rooms.ContainsKey(direction))
            {
                Console.WriteLine($"Room {Name} already has room for {direction.ToString()}");
                return false;
            }
            Rooms.Add(direction, room);
            return true;
        }
    }
}