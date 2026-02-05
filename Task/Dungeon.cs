namespace Task
{
    internal class Dungeon
    {
        Room[] rooms;
        public Dungeon()
        {
            rooms = new Room[5];
            rooms[0] = new Room(new Unit("Zombie", -5, -5), new Weapon("Golf club", 4, -9));
            rooms[1] = new Room(new Unit("Skeleton"), new Weapon("Sword"));
            rooms[2] = new Room(new Unit("Ninja"), new Weapon("Shuriken", 9, 14));
            rooms[3] = new Room(new Unit("Bandit"), new Weapon("Revolver"));
            rooms[4] = new Room(new Unit("Robot"), new Weapon("Blaster", 50, 80));
        }
        public void ShowRooms()
        {
            Console.WriteLine();
            foreach (Room room in rooms)
            {
                Console.WriteLine("Unit of room: " + room.Unit.Name);
                Console.WriteLine("Weapon of room: " + room.Weapon.Name);
                Console.WriteLine("Attack! " + room.Weapon.Damage.Get); //a little test
                Console.WriteLine("_____");
            }
        }
    }
}
