using Task.GameElements.Cards;

namespace Task.GameMechanics
{
    internal sealed class BlackJack : CasinoGameBase
    {
        private int _deckSize;
        private List<Card> _unshuffledDeck;
        private Queue<Card> _deck;
        public BlackJack(int deckSize) : base() 
        {
            //будем рассматривать толко размеры колод, кратные 36, иначе как-то странно и непонятно, зачем нужно количество карт
            if (deckSize <= 0)
                throw new BlackJackParametersException("Deck size can not be less or equal to 0");
            else if (deckSize % 36 != 0)
                throw new BlackJackParametersException("Deck size should be divisible by 36");
            _deckSize = deckSize;
        }
        protected override void FactoryMethod()
        {
            IEnumerable<CardSuit> allSuits = Enum.GetValues(typeof(CardSuit)).Cast<CardSuit>();
            IEnumerable<CardValue> allValues = Enum.GetValues(typeof(CardValue)).Cast<CardValue>();
            for (int i = 0; i < _deckSize / 36; i++)
                foreach (CardSuit suit in allSuits)
                    foreach (CardValue value in allValues)
                        _unshuffledDeck.Add(new Card(suit, value));
        }
        private void Shuffle() => _deck = new Queue<Card>(_unshuffledDeck.OrderBy(elem => _random.Next()));
        public override void PlayGame()
        {
        }
    }
}
