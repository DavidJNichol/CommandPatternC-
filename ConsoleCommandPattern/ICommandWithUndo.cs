using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCommandPattern
{
    /// <summary>
    /// Undo is a ICommand With and UndoCommand
    /// </summary>
    public interface ICommandWithUndo : ICommand
    {
        UndoCommand UndoCommand { get; set; }
    }
}