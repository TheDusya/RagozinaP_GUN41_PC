namespace Task.GameElements.Cards
{
    internal struct Card
    {
        public readonly CardSuit Suit;
        public readonly CardValue Value;
        public Card(CardSuit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }
    }
}
