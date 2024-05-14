using UnityEngine;

public class MoveInputHandler : MonoBehaviour
{
    [SerializeField] private CommandHandler _commandHandler;

    private void OnEnable()
    {
/*        InputController.Instance.OnMoveEventStarter += MoveCommand;
        InputController.Instance.OnMoveEventCanceled += MoveCommand;*/
    }

    private void OnDisable()
    {
/*        InputController.Instance.OnMoveEventStarter -= MoveCommand;
        InputController.Instance.OnMoveEventCanceled -= MoveCommand;*/
    }

    private void MoveCommand(Vector2 direction)
    {
        _commandHandler.SetCommand(new Command(CommandType.Move, direction));
    }

}
