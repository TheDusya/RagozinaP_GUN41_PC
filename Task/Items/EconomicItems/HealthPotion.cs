namespace Task.Items.EconomicItems
{
    public class HealthPotion : UsableItem
    {
        public uint HealthRestore => 7;
        public HealthPotion(string name = "Health Potion", int cost = 5) : base(name, cost) => Cost = cost;
    }
}
