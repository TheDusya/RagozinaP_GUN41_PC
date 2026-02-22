namespace Task.Units
{
    public abstract class Enemy : Unit
    {
        public Enemy(string name, uint maxHealth = 18, uint baseDamage = 2) : base(name, maxHealth, baseDamage) { }

        public override void Die()
        {
            Console.WriteLine($"{Name} is dead!");
        }
    }
}
