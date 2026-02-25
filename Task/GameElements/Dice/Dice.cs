namespace Task.GameElements.Dice
{
    internal struct Dice
    {
        private int _min;
        private int _max;
        private Random _random = new();
        public readonly int Number { get => _random.Next(_min-1, _max) + 1; } //не меньше min и не больше max, при этом max <= int.MaxValue
        public Dice(int min, int max)
        {
            if (min < 1)
                throw new WrongDiceNumberException($"Provided minimal value ({min}) is lesser than 1");
            if (max > int.MaxValue)
                throw new WrongDiceNumberException($"Provided maximal value ({max}) is greater than maximal possible value of int ({int.MaxValue})");
            if (max < min)
                throw new WrongDiceNumberException($"Provided maximal value ({max}) is less than minimal value ({min})");
            _min = min; 
            _max = max;
        }
    }
}
