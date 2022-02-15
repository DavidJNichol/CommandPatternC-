using ConsoleCommand;
using ConsoleCommandPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commands
{
    class CastSpellCommand : CommandWithUndo
    {
        private List<string> SpellNames;
        public CastSpellCommand()
        {
            this.CommandName = "Cast Spell";
            this.UndoCommand = new UndoCastSpellCommand(this);
            SpellNames = new List<string>();

            SpellNames.Add("Ice");
            SpellNames.Add("Fire");
            SpellNames.Add("Poison");
            SpellNames.Add("Electricity");
        }

        public override void Execute(GameComponent gc)
        {
            Random rand = new Random();
            Spell spell = new Spell();

            spell.Name = SpellNames[rand.Next(0, SpellNames.Count)];

            gc.CastSpell(spell);
            base.Execute(gc);
        }
    }

    public class UndoCastSpellCommand : UndoCommand
    {

        public UndoCastSpellCommand(CommandWithUndo command) : base(command)
        {

        }

        public override void Execute(GameComponent gc)
        {
            gc.UncastSpell();
            base.Execute(gc);
        }
    }
}
