namespace Task.Items.EconomicItems
{
    public abstract class UnusableItem : EconomicItem
    {
        public override bool IsStackable => true;
        public UnusableItem(string name) : base(name) { }
    }
}
