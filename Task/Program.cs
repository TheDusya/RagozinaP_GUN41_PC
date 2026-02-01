using System.Runtime.Remoting;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Unit unknownUnit = new();
            Console.WriteLine($"The name of the unknownUnit is {unknownUnit.Name}.");
            Unit zombie = new("Zombie Harold");
            Console.WriteLine($"{zombie.Name}'s health is {zombie.Health}, and real health is {zombie.GetRealHealth()}");
            float damage = 5f;
            bool dead = zombie.SetDamage(damage);
            string result = dead ? "slayed" : "not slayed";
            Console.WriteLine($"BOOM! {zombie.Name} got {damage} damage, now his health is {zombie.Health}, and real health is {zombie.GetRealHealth()}");
            Console.WriteLine($"{zombie.Name} is {result}!");
            Weapon club = new Weapon("Golf club", 8, -2);
            Console.WriteLine($"{club.Name}'s durability is {club.Durability}, and damage is {club.GetDamage()}");

        }
    }
}