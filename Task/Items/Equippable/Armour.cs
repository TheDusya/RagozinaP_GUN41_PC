namespace Task.Items
{
    public class Armour : EquippableItem
    {
        public uint Defence { get; }
        public Armour(string name= "Armour", uint maxDurability = 15, uint defence = 5) : base(name, maxDurability) => Defence = defence;
        public uint ReduceDamage(uint damage) => damage * (100-Defence) / 100;
    }
}
