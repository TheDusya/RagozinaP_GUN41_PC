using GamePrototype.Utils.UnitFactories;

namespace GamePrototype.Utils.DungeonBuilders
{
    public class DungeonBuilderHard : DungeonBuilder
    {
        protected override UnitFactoryHard MyUnitFactory { get; } = new();
    }
}
