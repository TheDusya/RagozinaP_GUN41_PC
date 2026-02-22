using Task.Items;
using Task.Items.Equippable;

namespace Task.Units
{
    public class PC : Unit
    {
        private readonly Dictionary<SlotNames, Item> equipped = new();
        public PC(string name, uint maxHealth = 30, uint baseDamage = 6) : base(name, maxHealth, baseDamage)
        {
            equipped[SlotNames.WeaponSlot] = new Sword();
            equipped[SlotNames.ArmourSlot] = new Armour();
        }

        public override void Die()
        {
            Console.WriteLine($"You died!\nGoodbye, {Name}...");
            System.Environment.Exit( 0 );
        }
    }
}
