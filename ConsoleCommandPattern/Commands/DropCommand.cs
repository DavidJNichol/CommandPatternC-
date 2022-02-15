using ConsoleCommand;
using ConsoleCommandPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commands
{
    class DropCommand : CommandWithUndo
    {
        public DropCommand()
        {
            this.CommandName = "Drop";
            this.UndoCommand = new UndoDropCommand(this);
        }

        public override void Execute(GameComponent gc)
        {
            gc.Drop();
            base.Execute(gc);
        }
    }

    public class UndoDropCommand : UndoCommand
    {

        public UndoDropCommand(CommandWithUndo command) : base(command)
        {

        }

        public override void Execute(GameComponent gc)
        {
            gc.Jump();
            base.Execute(gc);
        }
    }
}
