using GamePrototype.Combat;
using GamePrototype.Dungeon;
using GamePrototype.Units;
using GamePrototype.Utils;
using GamePrototype.Utils.DungeonBuilders;

namespace GamePrototype.Game
{
    public sealed class GameLoop
    {
        private Unit _player;
        private DungeonRoom _dungeon;
        private readonly CombatManager _combatManager = new CombatManager();
        private GameMode mode;
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
            Console.WriteLine("Choose your difficulty (1 - easy, 2 - hard):");
            DungeonBuilder dungeonBuilder;
            int answer;
            while (!int.TryParse(Console.ReadLine(), out answer) || !Enum.IsDefined(typeof(GameMode), answer))
                Console.WriteLine("(1 - easy, 2 - hard)");
            mode = (GameMode)answer;
            if (mode is GameMode.Easy) 
                dungeonBuilder = new DungeonBuilderEasy();
            else 
                dungeonBuilder = new DungeonBuilderHard();
            _dungeon = dungeonBuilder.BuildDungeon();
            Console.WriteLine("Enter your name");
            _player = dungeonBuilder.CreatePlayer(Console.ReadLine());
            Console.WriteLine($"Hello {_player.Name}");
        }

        private void StartGameLoop()
        {
            var currentRoom = _dungeon;
            
            while (currentRoom.IsFinal == false) 
            {
                StartRoomEncounter(currentRoom, out var success);
                if (!success) 
                {
                    Console.WriteLine("Game over!");
                    return;
                }
                DisplayRouteOptions(currentRoom);
                while (true) 
                {
                    if (Enum.TryParse<Direction>(Console.ReadLine(), out var direction) ) 
                    {
                        currentRoom = currentRoom.Rooms[direction];
                        break;
                    }
                    else 
                    {
                        Console.WriteLine("Wrong direction!");
                    }
                }
            }
            Console.WriteLine($"Congratulations, {_player.Name}");
            Console.WriteLine($"You've finished the game on {mode} mode.");
            Console.WriteLine("Result: ");
            Console.WriteLine(_player.ToString());
        }

        private void StartRoomEncounter(DungeonRoom currentRoom, out bool success)
        {
            Console.WriteLine($"You enter the room called {currentRoom.Name}");
            success = true;
            if (currentRoom.Loot != null) 
            {
                _player.AddItemToInventory(currentRoom.Loot);
            }
            if (currentRoom.Enemy != null) 
            {
                if (_combatManager.StartCombat(_player, currentRoom.Enemy) == _player)
                {
                    _player.HandleCombatComplete();
                    LootEnemy(currentRoom.Enemy);
                }
                else 
                {
                    success = false;
                }
            }

            void LootEnemy(Unit enemy)
            {
                _player.AddItemsFromUnitToInventory(enemy);
            }
        }

        private void DisplayRouteOptions(DungeonRoom currentRoom)
        {
            Console.WriteLine("Where to go?");
            foreach (var room in currentRoom.Rooms)
            {
                Console.Write($"{room.Key} - {(int) room.Key}\t");
            }
        }

        
        #endregion
    }
}
