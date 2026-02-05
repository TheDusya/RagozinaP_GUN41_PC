namespace Task
{
    internal class Unit
    {
        private float _health;
        public string Name { get; }
        public float Health { get => _health; }
        public Interval Damage { get; }
        private float Armor { get; }

        public Unit() : this("Unknown Unit") { }
        public Unit(string name) : this(name, 0, 5) { }
        public Unit(string name, int minDamage, int maxDamage)
        {
            _health = 5;
            Name = name;
            Damage = new(minDamage, maxDamage);
            Armor = 0.6f;
        }

        public float GetRealHealth() => Health * (1f + Armor);
        public bool SetDamage(float value)
        {
            _health = Health - value * Armor;
            return Health <= 0f;
        }
    }
}