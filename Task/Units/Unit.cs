using Task.Items;

namespace Task.Units
{
    public abstract class Unit
    {
        public string Name { get; }
        public uint Health { get; protected set; }
        public uint MaxHealth { get; }
        public uint BaseDamage { get; }
        public Inventory Inventory { get; protected set; } = new Inventory();
        protected Unit(string name, uint maxHealth, uint baseDamage)
        {
            Name = name;
            MaxHealth = maxHealth;
            BaseDamage = baseDamage;
        }
        public void TakeDamage(uint damage)
        {
            int realDamage = (int)CalculateRecievedDamage(damage);
            Health = (uint)Math.Max(Health - realDamage, 0);
            DamageRecieverHandler();
        }
        protected abstract uint CalculateRecievedDamage(uint damage);
        protected void DamageRecieverHandler()
        {
            Console.WriteLine($"{Name} is hit!");
            if (Health <= 0)
                Die();
        }
        public uint DealDamage() => CalculateDealtDamage();
        protected abstract uint CalculateDealtDamage();
        protected virtual void HandleBattleCompleted() { }
        public void Heal(uint delta) => 
            Health = Math.Min(Health + delta, MaxHealth);

        public void AddItemToInventory(Item item)
        {
            if (Inventory.TryAdd(item))
                Console.WriteLine($"{item.Name} was added to inventory by {Name}.");
            else
                Console.WriteLine($"{Name} can't add {item.Name} to inventory, no space left.");
        }

        public abstract void Die();

    }
}
