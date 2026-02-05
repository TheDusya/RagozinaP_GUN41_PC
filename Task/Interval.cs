namespace Task
{
    internal struct Interval
    {
        private int _min;
        public int Min { get => _min; }
        private int _max;
        public int Max { get => _max; }
        private readonly Random randomizer = new();
        public int Get => randomizer.Next(Min, Max);
        public Interval(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                Console.WriteLine($"WARNING! The min damage value for interval ({minValue}) was greater than max value ({maxValue}), so we switched them. Be more attentive!");
                (minValue, maxValue) = (maxValue, minValue);
            }
            if (minValue < 0) 
            {
                minValue = 0;
                Console.WriteLine($"WARNING! minValue was negative. It was changed to zero.");
            }
            if (maxValue < 0) 
            {
                maxValue = 0;
                Console.WriteLine($"WARNING! maxValue was negative. It was changed to zero.");
            }
            if (maxValue == minValue) 
            {
                maxValue += 10;
                Console.WriteLine($"WARNING! maxValue was equal to minValue.");
            }
            _min = minValue;
            _max = maxValue;
        }
    }
}
