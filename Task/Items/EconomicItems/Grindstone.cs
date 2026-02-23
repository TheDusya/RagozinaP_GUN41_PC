namespace Task.Items.EconomicItems
{
    public class Grindstone : UsableItem
    {
        public uint DurabilityRestore => 4;
        public Grindstone(string name = "Grindstone", int cost = 2) : base(name, cost) => Cost = cost;
    }
}
