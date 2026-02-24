using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Utils.UnitFactories;

namespace GamePrototype.Utils.DungeonBuilders
{
    public class DungeonBuilderEasy : DungeonBuilder
    {
        protected override UnitFactoryEasy MyUnitFactory { get; } = new();
    }
}
