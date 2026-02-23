using GamePrototype.Utils;

namespace GamePrototype.Items.EquipItems
{
    public abstract class Armour : EquipItem
    {
        public Armour(uint defence, uint durability, string name) : base(durability, name) => Defence = defence;

        private uint Defence { get; }

        public uint Defend()
        {
            if (Durability <= 0)
            {
                Console.WriteLine($"{Name} is broken and doesn't protect");
                return 0;
            }
            else
                return Defence;
        }
    }
}
