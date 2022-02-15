using ConsoleCommand;
using ConsoleCommandPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commands
{
    class JumpCommand : CommandWithUndo
    {
        public JumpCommand()
        {
            this.CommandName = "Enter";
            this.UndoCommand = new UndoJumpCommand(this);
        }

        public override void Execute(GameComponent gc)
        {
            gc.Jump();
            base.Execute(gc);
        }
    }

    public class UndoJumpCommand : UndoCommand
    {

        public UndoJumpCommand(CommandWithUndo command) : base(command)
        {

        }

        public override void Execute(GameComponent gc)
        {
            gc.Drop();
            base.Execute(gc);
        }
    }
}
