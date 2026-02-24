namespace Task.GameElements.Cards
{
    internal class Card
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
