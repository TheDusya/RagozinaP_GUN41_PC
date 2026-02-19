namespace Task.Items
{
    public abstract class UsableItem : EconomicItem
    {
        public override bool IsStackable => false;
        public int Cost { get; protected set; }
        public UsableItem(string name, int cost) : base(name) => Cost = cost;
    }
}
