namespace Task.CasinoMechanics
{
    internal class User
    {
        public string Name { get; }
        public int Bank { get; set; }
        public int Bet { get; private set; }
        public User(string name, int bank)
        {
            Name = name;
            Bank = bank;
            SetZeroBet();
        }
        public bool TrySetABet(int value)
        {
            if (Bank < value)
                return false;
            Bet = value;
            return true;
        }
        public void SetZeroBet() => Bet = 0;
        public void Win() 
        {
            Bank += Bet;
            Bet = 0;
        }
        public void Lose() 
        {
            Bank -= Bet;
            Bet = 0;
        }
    }
}
