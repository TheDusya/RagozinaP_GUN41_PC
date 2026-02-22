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
        public void TakeDamage(uint damage) => throw new NotImplementedException();
        public void DealDamage() => throw new NotImplementedException();
        public void Heal(uint delta) => 
            Health = Math.Min(Health + delta, MaxHealth);

        public abstract void Die();

    }
}
