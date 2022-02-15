using Commands;
using ConsoleCommand;
using System;
using System.Collections.Generic;


namespace ConsoleCommandPattern
{
    public class ConsoleCommandProcessor
    {
        bool playingGame = true;    //Bool used to loop unti Q is pressed



        //Fake Game Component
        public GameComponent FakeComponentReceiver { get; set; }

        //List of previously processed commands
        public Stack<ICommand> Commands { get; set; }

        public ConsoleCommandProcessor()
        {
            FakeComponentReceiver = new GameComponent();
            Commands = new Stack<ICommand>();
        }

        public void Run()
        {
            while (playingGame) //really bad game loop
            {
                ConsoleKeyInfo keyI = AskForCommand();
                Command command = GetCommandFromKey(keyI);
                ProcessCommand(command);

                //Update display from coponent
                Console.WriteLine(FakeComponentReceiver.About());
            }
        }

        public void ProcessCommand(Command command)
        {
            if (command != null)
            {
                if (command is ICommandWithUndo)
                {
                    Commands.Push((ICommandWithUndo)command); //only push commands with undo to the stack
                }
                command.Execute(FakeComponentReceiver);

            }
            else
            {
                Console.WriteLine("Sorry I don't know that command");
            }
        }

        private Command GetCommandFromKey(ConsoleKeyInfo keyI)
        {
            Command command = null;
            switch (keyI.Key)
            {
                case ConsoleKey.A:          //Move left
                case ConsoleKey.LeftArrow:
                    command = new MoveLeftCommand();
                    break;
                case ConsoleKey.D:          //Move right
                case ConsoleKey.RightArrow:
                    command = new MoveRightCommand();
                    break;
                case ConsoleKey.W:          //Move up
                case ConsoleKey.UpArrow:
                    command = new MoveUpCommand();
                    break;
                case ConsoleKey.S:          //Move down
                case ConsoleKey.DownArrow:
                    command = new MoveDownCommand();
                    break;
                case ConsoleKey.Spacebar:
                    command = new JumpCommand();
                    break;
                case ConsoleKey.X:
                    command = new DropCommand();
                    break;
                case ConsoleKey.O:
                    command = new OpenChestCommand();
                    break;
                case ConsoleKey.G:
                    command = new CastSpellCommand();
                    break;
                case ConsoleKey.Escape:     //Exit game
                case ConsoleKey.Q:
                    playingGame = false;
                    break;
                

                case ConsoleKey.Z:  //undo
                    if (Commands.Count > 0)
                    {
                        command = (Command)Commands.Pop();
                        if (command is ICommandWithUndo) //if the popped command has an undo command use it
                        {
                            command = ((ICommandWithUndo)command).UndoCommand;
                        }
                    }
                    break;
            }
            return command;
        }

        private ConsoleKeyInfo AskForCommand()
        {
            Console.Write(string.Format("Command Stack Size {0} \tArrow keys to move, space to jump, x to drop down, o to open chest, g to cast spell.", Commands.Count.ToString()));
            ConsoleKeyInfo ki = Console.ReadKey();
            Console.WriteLine(""); //new line
            return ki;
        }
    }
}