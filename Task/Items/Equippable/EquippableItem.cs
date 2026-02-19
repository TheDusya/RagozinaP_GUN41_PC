namespace Task.Items
{
    public abstract class EquippableItem : Item
    {
        public override bool IsStackable => false;
        public uint Durability { get; protected set; }
        public uint MaxDurability { get; }
        public EquippableItem(string name, uint maxDurability) : base(name) 
        {
            MaxDurability = maxDurability;
            Durability = maxDurability;
        }
        public void ReduceDurability(uint delta) => 
            Durability -= Math.Min(delta, Durability); //we don't want crazy wrong numbers here
            
        public void Repair(uint delta) => 
            Durability = Math.Min(Durability+delta, MaxDurability);
    }
}
