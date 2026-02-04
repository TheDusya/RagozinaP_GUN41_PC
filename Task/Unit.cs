namespace Task
{
    public class Unit
    {
        private float _health;
        public string Name { get; }
        public float Health { get => _health; }
        public int Damage { get; }
        private float Armor { get; }

        public Unit() : this("Unknown Unit") { }

        public Unit(string name)
        {
            _health = 5;
            Name = name;
            Damage = 5;
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