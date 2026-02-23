using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Utils;
using System.ComponentModel.Design;
using System.Text;

namespace GamePrototype.Units
{
    public sealed class Player : Unit
    {
        private readonly Dictionary<EquipSlot, EquipItem> _equipment = new();

        public Player(string name, uint health, uint maxHealth, uint baseDamage) : base(name, health, maxHealth, baseDamage)
        {            
        }

        public override uint GetUnitDamage()
        {
            if (_equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is Weapon weapon) 
            {
                var damage = BaseDamage + weapon.Attack();
                return damage;
            }
            return BaseDamage;
        }

        public override void HandleCombatComplete()
        {
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++) 
            {
                if (items[i] is EconomicItem economicItem) 
                {
                    UseEconomicItem(economicItem);
                    Inventory.TryRemove(items[i]);
                }
            }
        }

        public override void AddItemToInventory(Item item)
        {
            if (item is EquipItem equipItem) 
                if (_equipment.TryAdd(equipItem.Slot, equipItem))
                {
                    // Item was equipped
                    return;
                }
                else
                {
                    int answer;
                    var oldItem = _equipment[equipItem.Slot];
                    Console.WriteLine($"You found a new equipment - {equipItem.Name}. Do you want to replace your {oldItem.Name}? (1 - yes, 2 - no)");
                    while (!int.TryParse(Console.ReadLine(), out answer) || answer != 1 && answer != 2)
                        Console.WriteLine("(1 - yes, 2 - no)");
                    if (answer == 1) 
                    {
                        _equipment[equipItem.Slot] = equipItem;
                        base.AddItemToInventory(oldItem);
                    }
                    else
                        base.AddItemToInventory(equipItem);
                }
            else
                base.AddItemToInventory(item);
        }

        private void UseEconomicItem(EconomicItem economicItem)
        {
            if (economicItem is HealthPotion healthPotion) 
            {
                Console.Write($"You used Health potion! Your health was {Health}, ");
                Health += healthPotion.HealthRestore;
                Console.WriteLine($"now it is {Health}.");
            }
            else if (economicItem is Grindstone grindstone) 
            {
                if (_equipment.TryGetValue(EquipSlot.Weapon, out var weapon))
                {
                    Console.Write($"You used Grindstone! Your {weapon.Name} had {weapon.Durability} durability, ");
                    weapon.Repair(grindstone.DurabilityRestore);
                    Console.WriteLine($"now it has {weapon.Durability}.");
                }
            }
        }

        protected override uint CalculateAppliedDamage(uint damage)
        {
            uint wholeArmourDefend = 0;
            if (_equipment.TryGetValue(EquipSlot.BodyArmour, out var item1) && item1 is BodyArmour bodyArmour)
                wholeArmourDefend += bodyArmour.Defend();
            if (_equipment.TryGetValue(EquipSlot.Helmet, out var item2) && item2 is Helmet helmet)
                wholeArmourDefend += helmet.Defend();
            damage -= (uint)(damage * (wholeArmourDefend / 100f));
            return damage;
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
