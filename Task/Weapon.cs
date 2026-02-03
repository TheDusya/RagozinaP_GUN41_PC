using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Task
{
    internal class Weapon
    {
        public string Name { get; }
        public int minDamage { get; private set; }
        public int maxDamage { get; private set; }
        public float Durability { get; }

        public Weapon(string name)
        {
            Name = name;
            Durability = 1;
        }
        public Weapon(string name, int min, int max) :this(name)
        {
            SetDamageParams(min, max);
        }

        public void SetDamageParams(int min, int max)
        {
            if (min > max)
            {
                Console.WriteLine($"WARNING! The min damage value for {Name} ({min}) was greater than max value ({max}), so we switched them. Be more attentive!");
                (min, max) = (max, min);
            }
            minDamage = min < 1 ? 1 : min;
            maxDamage = max <= 1 ? 10 : max;
        }

        public int GetDamage() => (minDamage + maxDamage)/2;
    }
}