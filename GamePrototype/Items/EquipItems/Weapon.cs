using GamePrototype.Utils;

namespace GamePrototype.Items.EquipItems
{
    public abstract class Weapon : EquipItem
    {
        public Weapon(uint damage, uint durability, string name) : base(durability, name) => Damage = damage;

        private uint Damage { get; }
        public uint Attack()
        {
            if (Durability <= 0)
            {
                Console.WriteLine($"{Name} is broken and deals no damage");
                return 0;
            }
            else
                return Damage; //maybe weapon's durability should be reduced too, I don't know
        }

        public override EquipSlot Slot => EquipSlot.Weapon;
    }
}
