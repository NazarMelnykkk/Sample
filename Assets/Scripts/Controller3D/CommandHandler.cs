using UnityEngine;

public class CommandHandler : MonoBehaviour
{
    public Command CurrentCommand;
    private ICommandHandler moveCommandHandler;

    private void Awake()
    {
        moveCommandHandler = GetComponent<MoveHandler>();
    }

    public void SetCommand(Command newCommand)
    {
        CurrentCommand = newCommand;
    }

    private void Update()
    {
        if (CurrentCommand == null)
        {
            return;
        }

        ProcessCommand();
    }

    private void ProcessCommand()
    {
        switch (CurrentCommand.CommandType)
        {
            case CommandType.Move:
                ProcessMoveCommand();
                break;
        }

        if (CurrentCommand.IsComplete == true)
        {
            CompleteComand();
        }
    }

    private void CompleteComand()
    {
        CurrentCommand = null;
    }

    private void ProcessMoveCommand()
    {
        moveCommandHandler.ProcessCommand(CurrentCommand);
    }

    public CommandType GetCurrentCommandType()
    {
        if (CurrentCommand == null)
        {
            return CommandType.None;
        }

        return CurrentCommand.CommandType;
    }
}
