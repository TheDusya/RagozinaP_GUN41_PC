using Task.GameElements;
using Task.GameElements.Cards;

namespace Task.GameMechanics.BlackJackMechanics
{
    internal sealed class BlackJack : CasinoGameBase
    {
        private int _deckSize;
        private List<Card> _unshuffledDeck = new();
        private Queue<Card> _deck;
        private Dictionary<PlayerType, int> _currPoints = new() { { PlayerType.Human, 0 }, { PlayerType.Computer, 0 } };
        private int HumanPoints
        {
            get => _currPoints[PlayerType.Human];
            set => _currPoints[PlayerType.Human] = value;
        }
        private int ComputerPoints
        {
            get => _currPoints[PlayerType.Computer];
            set => _currPoints[PlayerType.Computer] = value;
        }

        public BlackJack(int deckSize=36) : base()
        {
            //будем рассматривать толко размеры колод, кратные 36, иначе как-то странно и непонятно, зачем нужно количество карт
            if (deckSize <= 0)
                throw new BlackJackParametersException("Deck size can not be less or equal to 0");
            else if (deckSize % 36 != 0)
                throw new BlackJackParametersException("Deck size should be divisible by 36");
            _deckSize = deckSize;
            FactoryMethod();
            //надеюсь, это не нарушение - я так и не смогла придумать, как тут можно вызывать FactoryMethod из родительского конструктора из-за инициализации _deckSize:(
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

        public override void PlayGame()
        {
            Preparations();
            HumanDrawsACard();
            HumanDrawsACard();
            ComputerDrawsACard();
            ComputerDrawsACard();
            while (ComputerPoints < 21 && HumanPoints < 21)
            {
                Console.WriteLine("Let's do another round!");
                HumanDrawsACard();
                ComputerDrawsACard();
            }
            InvokeResult();
        }

        private void Preparations()
        {
            HumanPoints = 0;
            ComputerPoints = 0;
            WriteIntro();
            Shuffle();
        }

        private void WriteIntro() => Console.WriteLine("Welcome to BlackJack game!");
        private void Shuffle() => _deck = new Queue<Card>(_unshuffledDeck.OrderBy(elem => _random.Next()));
        private void ComputerDrawsACard() => SomeoneDrawsACard(PlayerType.Computer);
        private void HumanDrawsACard() => SomeoneDrawsACard(PlayerType.Human);
        private void SomeoneDrawsACard(PlayerType type)
        {
            Card card = _deck.Dequeue();
            int currPoints = _currPoints[type];
            int points = GetValue(card, currPoints);
            Console.WriteLine($"{type} draws a {card} ({points} points).");
            if (currPoints != 0)
                Console.WriteLine($"In total, {type} has {currPoints + points} points."); //no need to write this for the first time
            _currPoints[type] += points;
        }

        private static int GetValue(Card card, int currPoints) {
            if (card.Value is not CardValue.Ace)
                return (int)card.Value;
            else if (currPoints <= 10)
                return 11;
            else
                return 1;
        }

        private void InvokeResult()
        {
            if (HumanPoints <= 21 && (ComputerPoints > 21 || HumanPoints > ComputerPoints))
                OnWinInvoke();
            else if (ComputerPoints <= 21 && (HumanPoints > 21 || ComputerPoints > HumanPoints))
                OnLooseInvoke();
            else
                OnDrawInvoke();
        }
    }
}
