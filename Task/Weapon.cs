namespace Task
{
    internal class Weapon
    {
        public string Name { get; }
        public Interval Damage;
        public float Durability { get; }

        public Weapon(string name, int min=1, int max=5)
        {
            Name = name;
            Durability = 1;
            SetDamageParams(min, max);
        }
        public void SetDamageParams(int min, int max) => Damage = new Interval(min, max);
        public int GetDamage() => Damage.Get;
    }
}