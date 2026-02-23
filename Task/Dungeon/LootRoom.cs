using Task.Items;

namespace Task.Dungeon
{
    internal class LootRoom : DungeonRoom
    {
        public Item Loot { get; }
        public LootRoom(string name, Item item) : base(name) => Loot = item;
        public virtual void WriteIntro()
        {
            Console.WriteLine($"You enter the treasure room - {Name}. It contains {Loot.Name}.");
        }
    }
}
