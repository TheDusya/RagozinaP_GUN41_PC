using Task.Units;

namespace Task.Dungeon
{
    internal class EnemyRoom : DungeonRoom
    {
        public Enemy Enemy { get; }
        public EnemyRoom(string name, Enemy monster) : base(name) => Enemy = monster;
        public override void WriteIntro()
        {
            Console.WriteLine($"You enter the dangerous room - {Name}. {Enemy.Name} was hiding here.\nPrepare to fight!");
        }
    }
}
