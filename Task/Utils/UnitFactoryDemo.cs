using Task.Items.EconomicItems;
using Task.Items.Equippable;
using Task.Units;

namespace Task.Utils
{
    public class UnitFactoryDemo
    {
        public static PC CreatePlayer(string name)
        {
            var player = new PC(name, 30, 6);
            player.AddItemToInventory(new HealthPotion());
            player.Equip(new Sword());
            player.Equip(new Armour());
            return player;
        }

        public static Enemy CreateGoblinEnemy() => new Goblin();
    }
}
