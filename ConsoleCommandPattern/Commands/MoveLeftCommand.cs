using ConsoleCommand;
using ConsoleCommandPattern;

namespace Commands
{
    public class MoveLeftCommand : CommandWithUndo
    {
        public MoveLeftCommand()
        {
            this.CommandName = "Move Left";
            this.UndoCommand = new UndoMoveLeftCommand(this);
        }

        public override void Execute(GameComponent gc)
        {
            gc.MoveLeft();
            base.Execute(gc);
        }
    }

    public class UndoMoveLeftCommand : UndoCommand
    {

        public UndoMoveLeftCommand(CommandWithUndo command) : base(command)
        {

        }

        public override void Execute(GameComponent gc)
        {
            gc.MoveRight();
            base.Execute(gc);
        }
    }
}