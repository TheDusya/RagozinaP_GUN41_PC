using Task.Items;
using Task.Items.Equippable;
using Task.Utils;

namespace Task.Units
{
    public class PC : Unit
    {
        private readonly Dictionary<SlotType, Item> equipped = new();
        private Armour? Armour =>
            equipped.TryGetValue(SlotType.Armour, out var armour) ? (Armour)armour : null;
        private Weapon? Weapon =>
            equipped.TryGetValue(SlotType.Weapon, out var weapon) ? (Weapon)weapon : null;
        public PC(string name, uint maxHealth = 30, uint baseDamage = 6) : base(name, maxHealth, baseDamage) {}
        public void Equip(EquippableItem equippableItem)
        {
            var slot = equippableItem.Slot;
            if (equipped.TryGetValue(slot, out var oldItem))
            {
                equipped[slot] = equippableItem;
                AddItemToInventory(oldItem);
            }
            else
                equipped[slot] = equippableItem;
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
