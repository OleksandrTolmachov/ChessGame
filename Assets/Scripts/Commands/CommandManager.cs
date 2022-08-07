using System;
using System.Collections.Generic;

public class CommandManager
{
    private static Lazy<CommandManager> _instance = new(() => new CommandManager());
    public static CommandManager Instance => _instance.Value;

    private Stack<ICommand> _commandHistory = new();

    private CommandManager()
    {
    }

    public void Execute(ICommand command)
    {
        command.Execute();
        _commandHistory.Push(command);
        if(_commandHistory.Count > 20)
        {
            _commandHistory.Clear();
        }
    }
}
