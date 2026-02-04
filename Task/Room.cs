namespace Task
{
    internal struct Room
    {
        public Unit Unit;
        public Weapon Weapon;
        public Room(Unit unit, Weapon weapon)
        {
            this.Unit = unit;
            this.Weapon = weapon;
        }
    }
}
