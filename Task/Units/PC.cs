using System.Text;
using Task.Items;
using Task.Items.EconomicItems;
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

        public override void HandleCombatComplete()
        {
            foreach (var item in Inventory.Items.ToList())
                if (item is EconomicItem economicItem)
                {
                    UseEconomicItem(economicItem);
                    Inventory.TryRemove(item);
                }
        }

        private void UseEconomicItem(EconomicItem economicItem)
        {
            if (economicItem is HealthPotion healthPotion)
            {
                Console.Write($"You used Health potion! Your health was {Health}, ");
                Heal(healthPotion.HealthRestore);
                Console.WriteLine($"now it is {Health}.");
            }
            else if (economicItem is Grindstone grindstone)
            {
                if (Weapon != null)
                { 
                    Console.Write($"You used Grindstone! Your {Weapon.Name} had {Weapon.Durability} durability, ");
                    Weapon.Repair(grindstone.DurabilityRestore);
                    Console.WriteLine($"now it has {Weapon.Durability}.");
                }
            }
        }

        public void AddItemsFromUnitToInventory(Unit unit)
        {
            foreach (var item in unit.Inventory.Items)
                AddItemToInventory(item);
        }

        public override void Die()
        {
            Console.WriteLine($"You died!\nGoodbye, {Name}...");
            System.Environment.Exit( 0 );
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(Name);
            builder.AppendLine($"Health {Health}/{MaxHealth}");
            builder.AppendLine("Loot:");
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++)
            {
                builder.AppendLine($"[{items[i].Name}] : {items[i].Amount}");
            }
            return builder.ToString();
        }
    }
}
