namespace Task.GameMechanics
{
    internal class BlackJackParametersException : Exception
    {
        public BlackJackParametersException() : base() { }
        public BlackJackParametersException(string message) : base(message) { }
        public BlackJackParametersException(string message, Exception inner) : base(message, inner) { }
    }
}
