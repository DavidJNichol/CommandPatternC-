using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCommandPattern
{
    public class Spell
    {
        string name = "";

        int damage = 0;
        public string Name { get { return name; } set { name = value; } }
        public int Damage { get { return damage; } set { damage = value; } }
        public Spell()
        {
            Random rand = new Random();

            damage = rand.Next(0, 101);
        }
    }
}
