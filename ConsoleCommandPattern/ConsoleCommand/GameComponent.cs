using ConsoleCommandPattern;
using System;
using System.Collections.Generic;

namespace ConsoleCommand
{
    /// <summary>
    /// Fake class for GameComponent it fae moves by having a X and a Y int
    /// </summary>
    public class GameComponent
    {

        protected int _X, _Y,_Z;
        protected List<Item> _inventory;
        protected List<Spell> _spellsCast;

        public int X { get { return _X; } protected set { _X = value; } }
        public int Y { get { return _Y; } protected set { _Y = value; } }
        public int Z { get { return _Z; } protected set { _Z = value; } }
        public List<Spell> SpellsCast { get { return _spellsCast; } protected set { _spellsCast = value; } }
        public List<Item> Inventory { get { return _inventory; } protected set { _inventory = value; } }

        public GameComponent()
        {
            Inventory = new List<Item>();
            SpellsCast = new List<Spell>();
        }

        internal void MoveRight()
        {
            //move right
            X++;
        }

        internal void MoveLeft()
        {
            //move left
            X--;
        }

        internal void MoveUp()
        {
            //Move up
            Y++;
        }

        internal void MoveDown()
        {
            //Move down
            Y--;
        }

        internal void Jump()
        {
            Z++;
        }

        internal void Drop()
        {
            Z--;
        }

        internal void OpenChest(Item item)
        {
            Inventory.Add(item);
        }

        internal void Dropitem()
        {
            Inventory.RemoveAt(Inventory.Count - 1);
        }

        internal void CastSpell(Spell spell)
        {
            SpellsCast.Add(spell);
        }

        internal void UncastSpell()
        {
            SpellsCast.RemoveAt(SpellsCast.Count - 1);
        }

        public string About()
        {
            string about = $"Location {X}|{Y}|{Z}\n";

            for(int i = 0; i < Inventory.Count; i++)
                about += $"Inventory: {Inventory[i].Name}\n";

            for (int i = 0; i < SpellsCast.Count; i++)
            {
                about += $"Spells Cast: {SpellsCast[i].Name}\n";
                about += $"Damage: {SpellsCast[i].Damage}\n";
            }
                
            return about;
        }
    }
}