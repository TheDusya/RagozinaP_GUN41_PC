using Task.Units;

namespace Task.Items.Equippable
{
    public abstract class Weapon : EquippableItem
    {
        public uint Attack { get; }
        public override SlotType Slot => SlotType.Weapon;
        public Weapon(string name, uint maxDurability = 15, uint attack = 10) : base(name, maxDurability) => Attack = attack;
    }
}
