namespace Task.GameElements.Dice
{
    internal class WrongDiceNumberException : Exception
    {
        public WrongDiceNumberException() : base() { }
        public WrongDiceNumberException(string message) : base(message) { }
        public WrongDiceNumberException(string message, Exception inner) : base(message, inner) { }
    }
}
