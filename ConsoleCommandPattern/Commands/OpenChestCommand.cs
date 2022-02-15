using ConsoleCommand;
using ConsoleCommandPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commands
{
    class OpenChestCommand : CommandWithUndo
    {
        private List<string> ItemNames;
        public OpenChestCommand()
        {
            this.CommandName = "Open Chest";
            this.UndoCommand = new UndoOpenChestCommand(this);

            ItemNames = new List<string>();

            ItemNames.Add("Sword");
            ItemNames.Add("Key");
            ItemNames.Add("Coin");
            ItemNames.Add("Orb");
            ItemNames.Add("Potion");
        }

        public override void Execute(GameComponent gc)
        {
            Random rand = new Random();
            Item item = new Item();
            item.Name = ItemNames[rand.Next(0,ItemNames.Count)];

            gc.OpenChest(item);
            base.Execute(gc);
        }
    }

    public class UndoOpenChestCommand : UndoCommand
    {

        public UndoOpenChestCommand(CommandWithUndo command) : base(command)
        {

        }

        public override void Execute(GameComponent gc)
        {
            gc.Dropitem();
            base.Execute(gc);
        }
    }
}
