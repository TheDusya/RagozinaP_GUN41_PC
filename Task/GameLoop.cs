using Task.Combat;
using Task.Dungeon;
using Task.Units;
using Task.Utils;

namespace GamePrototype
{
    public sealed class GameLoop
    {
        private PC _player;
        private DungeonRoom _dungeon;
        private readonly CombatManager _combatManager = new CombatManager();

        public void StartGame()
        {
            Initialize();
            Console.WriteLine("Entering the dungeon");
            StartGameLoop();
        }

        #region Game Loop

        private void Initialize()
        {
            Console.WriteLine("Welcome, player!");
            _dungeon = DungeonBuilder.BuildDungeon();
            Console.WriteLine("Enter your name");
            _player = UnitFactoryDemo.CreatePlayer(Console.ReadLine());
            Console.WriteLine($"Hello {_player.Name}");
        }

        private void StartGameLoop()
        {
            var currentRoom = _dungeon;
            currentRoom.WriteIntro();
            while (currentRoom.IsFinal == false)
            {
                StartRoomEncounter(currentRoom, out var success);
                if (!success)
                {
                    Console.WriteLine("Game over!");
                    return;
                }
                currentRoom.WriteInstructions();
                while (true)
                    if (Enum.TryParse<Direction>(Console.ReadLine(), out var direction) && 
                        currentRoom.Rooms.TryGetValue(direction, out var newCurrentRoom))
                    {
                        currentRoom = newCurrentRoom;
                        break;
                    }
                    else
                        Console.WriteLine("Wrong direction!");
            }
            Console.WriteLine($"Congratulations, {_player.Name}");
            Console.WriteLine("Result: ");
            Console.WriteLine(_player.ToString());
        }

        private void StartRoomEncounter(DungeonRoom currentRoom, out bool success)
        {
            success = true;
            if (currentRoom is LootRoom lootRoom)
                _player.AddItemToInventory(lootRoom.Loot);
            else if (currentRoom is EnemyRoom enemyRoom)
            {
                if (_combatManager.StartCombat(_player, enemyRoom.Enemy) == _player)
                {
                    _player.HandleCombatComplete();
                    _player.AddItemsFromUnitToInventory(enemyRoom.Enemy);
                }
                else
                    success = false;
            }
        }
        #endregion
    }
}