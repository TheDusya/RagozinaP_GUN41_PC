namespace Task.Items.EconomicItems
{
    public class Gold : UnusableItem
    {
        public override bool IsStackable => true;
        public Gold(uint amount) : base("Gold") => Amount = amount;
    }
}
