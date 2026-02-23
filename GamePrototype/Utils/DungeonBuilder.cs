using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;

namespace GamePrototype.Utils
{
    public static class DungeonBuilder
    {
        public static DungeonRoom BuildDungeon()
        {
            var enter = new DungeonRoom("Enter");
            var axeRoom = new DungeonRoom("AxeRoom", new Axe(20, 10, "CoolAxe"));
            var monsterRoom = new DungeonRoom("Monster", UnitFactoryDemo.CreateGoblinEnemy());
            var anotherMonsterRoom = new DungeonRoom("AnotherMonster", UnitFactoryDemo.CreateGoblinEnemy());
            var emptyRoom = new DungeonRoom("Empty");
            var lootRoom = new DungeonRoom("Loot1", new Gold());
            var lootStoneRoom = new DungeonRoom("Loot1", new Grindstone("Stone"));
            var finalRoom = new DungeonRoom("Final", new Grindstone("Stone1"));

            enter.TrySetDirection(Direction.Forward, axeRoom);
            enter.TrySetDirection(Direction.Left, emptyRoom);

            axeRoom.TrySetDirection(Direction.Right, monsterRoom);

            monsterRoom.TrySetDirection(Direction.Forward, lootRoom);
            monsterRoom.TrySetDirection(Direction.Left, emptyRoom);

            emptyRoom.TrySetDirection(Direction.Forward, lootStoneRoom);

            lootRoom.TrySetDirection(Direction.Forward, finalRoom);

            lootStoneRoom.TrySetDirection(Direction.Forward, anotherMonsterRoom);
            anotherMonsterRoom.TrySetDirection(Direction.Forward, finalRoom);

            return enter;
        }
    }
}
