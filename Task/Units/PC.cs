using Task.Items;
using Task.Items.Equippable;
using static System.Net.Mime.MediaTypeNames;

namespace Task.Units
{
    public class PC : Unit
    {
        private readonly Dictionary<SlotNames, Item> equipped = new();
        private Armour? Armour =>
            equipped.TryGetValue(SlotNames.ArmourSlot, out var armour) ? (Armour)armour : null;
        private Weapon? Weapon =>
            equipped.TryGetValue(SlotNames.WeaponSlot, out var weapon) ? (Weapon)weapon : null;
        public PC(string name, uint maxHealth = 30, uint baseDamage = 6) : base(name, maxHealth, baseDamage)
        {
            equipped[SlotNames.WeaponSlot] = new Sword();
            equipped[SlotNames.ArmourSlot] = new Armour();
        }
        protected override uint CalculateRecievedDamage(uint damage)
        {
            if (Armour != null)
                return Armour.ReduceDamage(damage);
            else
                return damage;
        }
        protected override uint CalculateDealtDamage()
        {
            if (Weapon != null)
                return Weapon.Attack + BaseDamage;
            else
                return BaseDamage;

        }
        protected override void HandleBattleCompleted()
        {

        }
        public override void Die()
        {
            Console.WriteLine($"You died!\nGoodbye, {Name}...");
            System.Environment.Exit( 0 );
        }
    }
}
