namespace Task.Items
{
    public class HealthPotion : UsableItem
    {
        public HealthPotion(string name = "Health Potion", int cost = 5) : base(name, cost) => Cost = cost;
    }
}
