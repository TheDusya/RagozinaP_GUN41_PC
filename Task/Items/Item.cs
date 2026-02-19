namespace Task.Items
{
    public abstract class Item
    {
        public abstract bool IsStackable { get; }
        public virtual uint Amount { get; protected set; }
        public string Name { get; }
        protected Item(string name)
        {
            Name = name;
            Amount = 1;
        }
        public bool TryStack(Item item)
        {
            if (!IsStackable) 
                return false;
            Amount += item.Amount;
            return true;
        } 
    }
}
