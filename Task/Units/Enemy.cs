namespace Task.Units
{
    public abstract class Enemy : Unit
    {
        public Enemy(string name, uint maxHealth = 18, uint baseDamage = 2) : base(name, maxHealth, baseDamage) { }
        protected override uint CalculateRecievedDamage(uint damage) => damage;
        protected override uint CalculateDealtDamage() => BaseDamage;
        protected override void HandleBattleCompleted() => Health = MaxHealth;
        public override void Die() => Console.WriteLine($"{Name} is dead!");
    }
}
