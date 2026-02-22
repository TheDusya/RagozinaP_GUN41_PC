using Task.Items;

namespace Task.Units
{
    public class Inventory
    {
        private uint size = Constants.INVENTORY_SIZE;
        private List<Item> _items = new();
        private List<Item> Items {  get { return _items; } } //TODO: add sorting
        public Inventory() { }
        public bool TryAdd(Item item)
        {
            if (item.IsStackable)
                foreach (var myItem in Items)
                    if (myItem.TryStack(item))
                        return true;
            if (Items.Count >= size)
                return false;
            else
                Items.Add(item);
            return true;
        }
    }
}
