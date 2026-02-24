using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Units;

namespace GamePrototype.Utils.UnitFactories
{
    public class UnitFactoryHard : UnitFactory
    {
        public override Unit CreatePlayer(string name)
        {
            var player = new Player(name, 20, 30, 6);
            player.AddItemToInventory(new Sword(10, 15, "Sword"));
            player.AddItemToInventory(new Helmet(5, 10, "Helmet"));
            return player;
        }

        public override Unit CreateGoblinEnemy() => new Goblin(GameConstants.Goblin, 25, 25, 3);
    }
}
