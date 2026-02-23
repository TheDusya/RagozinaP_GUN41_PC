using Task.Units;

namespace Task.Combat
{
    internal class CombatManager
    {
        private readonly Random _random = new();

        public Unit StartCombat(PC player, Enemy enemy) => PlayCombatRoutine(player, enemy);

        private Unit PlayCombatRoutine(PC player, Enemy enemy)
        {
            WriteInstructions();
            while (player.Health > 0 && enemy.Health > 0)
                if (Enum.TryParse<RockPaperScissors>(Console.ReadLine(), out var rockPaperScissors))
                    HandleCombatInput(player, enemy, rockPaperScissors);
                else
                    WriteInstructions();
            if (player.Health > 0 && enemy.Health == 0)
                return player;
            else if (player.Health == 0 && enemy.Health > 0)
                return enemy;
            throw new Exception("no one won, something went wrong");
        }

        private void WriteInstructions() => Console.WriteLine($"Type {RockPaperScissors.Rock} ({(int)RockPaperScissors.Rock})" +
            $"or {RockPaperScissors.Paper} ({(int)RockPaperScissors.Rock})" +
            $"or {RockPaperScissors.Scissors} ({(int)RockPaperScissors.Rock})");

        private void HandleCombatInput(PC player, Enemy enemy, RockPaperScissors playerInput)
        {
            var enemyInput = (RockPaperScissors)_random.Next(1, 3);
            Console.WriteLine($"Result player = {playerInput} and enemy = {enemyInput}");
            if (playerInput == enemyInput)
                Console.WriteLine("Combatants tried to hit, but missed :(");
            else if (Does1Win(playerInput, enemyInput))
                ApplyDamage(player, enemy);
            else
                ApplyDamage(enemy, player);

        }

        private bool Does1Win(RockPaperScissors input1, RockPaperScissors input2)
        {
            if (input1 == RockPaperScissors.Rock)
                return input2 == RockPaperScissors.Paper;
            else if (input1 == RockPaperScissors.Paper)
                return input2 == RockPaperScissors.Scissors;
            else
                return input2 == RockPaperScissors.Rock;
        }
        private void ApplyDamage(Unit attacker, Unit defender)
        {
            defender.TakeDamage(attacker.DealDamage());
            Console.WriteLine($"{attacker.Name} hits {defender.Name}. {defender.Name} health: {defender.Health}/{defender.MaxHealth}");
            if (defender.Health == 0)
            {
                Console.WriteLine($"{defender.Name} is dead!");
            }
        }

    }
}
