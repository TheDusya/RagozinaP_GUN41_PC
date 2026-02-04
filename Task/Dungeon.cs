namespace Task
{
    internal class Dungeon
    {
        Room[] rooms;
        public Dungeon()
        {
            rooms = new Room[5];
            rooms[0] = new Room(new Unit("Zombie"), new Weapon("Golf club"));
            rooms[1] = new Room(new Unit("Skeleton"), new Weapon("Sword"));
            rooms[2] = new Room(new Unit("Ninja"), new Weapon("Shuriken"));
            rooms[3] = new Room(new Unit("Bandit"), new Weapon("Revolver"));
            rooms[4] = new Room(new Unit("Robot"), new Weapon("Blaster"));
        }
        public void ShowRooms()
        {
            foreach (Room room in rooms)
            {
                Console.WriteLine("Unit of room " + room.Unit);
                Console.WriteLine("Weapon of room" + room.Weapon);
                Console.WriteLine("_____");
            }
        }
    }
}
