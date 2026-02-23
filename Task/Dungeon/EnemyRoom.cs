using Task.Units;

namespace Task.Dungeon
{
    internal class EnemyRoom : DungeonRoom
    {
        Enemy Monster { get; }
        public EnemyRoom(string name, Enemy monster) : base(name) => Monster = monster;
        public override void WriteIntro()
        {
            Console.WriteLine($"You enter the dangerous room - {Name}. {Monster.Name} was hiding here.\nPrepare to fight!");
        }
    }
}
