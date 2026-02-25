using Task.GameElements.Dice;

namespace Task.GameMechanics.DiceGameMechanics
{
    internal class DiceGame : CasinoGameBase
    {
        private int _diceNum;
        private int _minNum;
        private int _maxNum;
        private List<Dice> _diceList;
        public DiceGame(int diceNum, int min, int max) : base()
        {
            if (diceNum <= 0)
                throw new DiceGameParametersException("Dice number can not be less or equal to 0");
            _diceNum = diceNum;
            _minNum = min;
            _maxNum = max;
            FactoryMethod();
        }

        protected override void FactoryMethod()
        {
            _diceList = new List<Dice>();
            try
            {
                for (int i = 0; i < _diceNum; i++)
                    _diceList.Add(new Dice(_minNum, _maxNum));
            }
            catch(WrongDiceNumberException innerException)
            {
                throw new DiceGameParametersException("Wrong dice parameters", innerException);
            }
        }

        public override void PlayGame()
        {
            WriteIntro();
            int computerPoints = RollTheDice();
            Console.WriteLine($"Computer gets {computerPoints} points!");
            int humanPoints = RollTheDice();
            Console.WriteLine($"Human gets {humanPoints} points!");
            if (humanPoints > computerPoints)
                OnWinInvoke();
            else if (humanPoints < computerPoints)
                OnLooseInvoke();
            else
                OnDrawInvoke();
        }

        private void WriteIntro() => Console.WriteLine("Welcome to dice game!");
        private int RollTheDice() => _diceList.Sum(dice => dice.Number);
    }
}
