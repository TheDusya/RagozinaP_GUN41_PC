using GamePrototype.Items.EconomicItems;
using GamePrototype.Units;

namespace GamePrototype.Utils.UnitFactories
{
    public abstract class UnitFactory
    {
        public abstract Unit CreatePlayer(string name);
        public abstract Unit CreateGoblinEnemy();
    }
}
