namespace Task.GameMechanics
{
    internal class DiceGameParametersException : Exception
    {
        public DiceGameParametersException() : base() { }
        public DiceGameParametersException(string message) : base(message) { }
        public DiceGameParametersException(string message, Exception inner) : base(message, inner) { }
    }
}
