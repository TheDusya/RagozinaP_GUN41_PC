using System.Dynamic;
using Task.GameMechanics;
using Task.GameMechanics.BlackJackMechanics;
using Task.GameMechanics.DiceGameMechanics;
using Task.SaveLoadService;

namespace Task.CasinoMechanics
{
    internal class Casino : IGame
    {
        private FileSystemSaveLoadService _saveLoadService;
        private const int _maxBankValue = 500;
        private User _currUser;
        private BlackJack _blackJack;
        private DiceGame _diceGame;

        public Casino()
        {
            _blackJack = new BlackJack(36);
            _diceGame = new DiceGame(3, 1, 6);
            _saveLoadService = new("SavedDataDir");
            CasinoGameBase.OnWin += HandleWin;
            CasinoGameBase.OnLose += HandleLose;
            CasinoGameBase.OnDraw += HandleDraw;
        }
        private bool YesOrNo(string var1, string var2)
        {
            int answer;
            while (!int.TryParse(Console.ReadLine(), out answer) || answer < 1 || answer > 2)
                Console.WriteLine($"1 - {var1}, 2 - {var2}");
            return answer == 1;
        }
        public void StartGame()
        {
            Console.WriteLine("Greetings and welcome, dear gambler!");
            Console.WriteLine("Do you have a profile? (1 - yes, 2 - no)");
            bool answer = YesOrNo("yes", "no");
            if (!answer)
                CreateAccount();
            else
                GreetTheExistingUser();
            Console.WriteLine("Choose a game (1 - Black Jack, 2 - dice)");
            bool isBlackJack = YesOrNo("Black Jack", "dice");
            Console.WriteLine("Make your bet!");
            GetABet();
            if (isBlackJack)
                _blackJack.PlayGame();
            else
                _diceGame.PlayGame();
            //странно, что по ТЗ создаётся впечатление, будто мы сначала выводим результат ставки, потом результат игры.
            //но это читалось неоднозначно и я не стала реализовывать в таком виде.
            Console.WriteLine($"See you later, {_currUser.Name}! Byeeee!");
            SaveResults();
        }

        private void GetABet()
        {
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out int bet))
                    Console.WriteLine("Come on, that's not even a number!");
                else if (bet <= 0)
                    Console.WriteLine("Fon't be a loser, make a real bet!");
                else if (!_currUser.TrySetABet(bet))
                    Console.WriteLine("You don't have enough money for that!");
                else break;
            }
        }

        private void CreateAccount()
        {
            Console.WriteLine("Enter your name. Letters and numbers only, please");
            string name = FindAGoodName();
            Console.WriteLine($"Nice to meet you, {name}! We gift you 100 netodollars as a greeting gift :)");
            _saveLoadService.Save("100", name);
            TryLogIn(name);
        }

        private string FindAGoodName()
        {
            string name;
            while (true)
            {
                name = Console.ReadLine();
                if (name != null && !name.Where(ch => !char.IsNumber(ch) && !char.IsLetter(ch)).Any())
                    if (!_saveLoadService.DoesFileExist(name))
                        break;
                    else
                        Console.WriteLine("This user already exists!");
                else
                    Console.WriteLine("Letters and numbers only!");
            }
            return name;
        }

        private bool TryLogIn(string name)
        {
            string bank;
            try
            {
                bank = _saveLoadService.Load(name);
            }
            catch (SaveLoadServiceException)
            {
                return false;
            }
            if (int.TryParse(bank, out var bankNum))
            {
                _currUser = new User(name, bankNum);
                return true;
            }
            else
                throw new Exception("files don't work well");
        }

        private void GreetTheExistingUser()
        {
            Console.WriteLine("Enter your name to log in.");
            while (!TryLogIn(Console.ReadLine()))
                Console.WriteLine("Not a valid name. Try again. If you lied about having an account, welcome to the endless loop.");
            Console.WriteLine($"Hello-hello, {_currUser.Name}!");
            if (_currUser.Bank == 0)
            {
                Console.WriteLine($"No money? Kicked!");
                Environment.Exit(0);
            }
            Console.WriteLine($"You have {_currUser.Bank} netodollars in your bank, have fun!");
        }

        private void SaveResults() => _saveLoadService.Save(_currUser.Bank.ToString(), _currUser.Name);

        private void HandleWin()
        {
            Console.WriteLine("Hurray, you won :(");
            _currUser.Win();
            if (_currUser.Bank > _maxBankValue)
            {
                int rest = _currUser.Bank - _maxBankValue;
                _currUser.Bank = _maxBankValue;
                Console.WriteLine($"You played too well, our casino went bancrupt, we couldn't pay you your {rest} netodollars! :(");
                Console.WriteLine($"Don't worry, the new casino is being built at the same place...");
                _currUser.Bank /= 2;
                Console.WriteLine($"You wasted half of your bank money in casino’s bar.");
                //было два варианта, я не знала, что правильно, поэтому оба.
            }
        }
        private void HandleLose()
        {
            Console.WriteLine("Oh no, you've lost! :D");
            _currUser.Lose();
        }
        private void HandleDraw()
        {
            Console.WriteLine("Wow, powers were equal... draw :/");
            _currUser.SetZeroBet();
        }
    }
}
