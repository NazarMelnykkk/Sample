using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public static CharacterInputActions InputActions;

    private void Awake()
    {
        InputActions = new CharacterInputActions();
        InputActions.Enable();
    }

    private void OnEnable()
    {
        InputActions.Character.Jump.performed += JumpPerformed;

        InputActions.Character.Accept.performed += AcceptPerformed;

    }

    private void OnDisable()
    {
        InputActions.Character.Jump.performed -= JumpPerformed;

        InputActions.Character.Accept.performed -= AcceptPerformed;

    }

    #region Jump
    public Action OnJumpPerformedEvent;

    private void JumpPerformed(InputAction.CallbackContext context)
    {
        OnJumpPerformedEvent?.Invoke();
    }

    #endregion

    #region Accept

    public Action OnAcceptPerformedEvent;

    private void AcceptPerformed(InputAction.CallbackContext context)
    {
        OnAcceptPerformedEvent?.Invoke();
    }
    #endregion

    #region Jump

    #endregion

    #region Jump

    #endregion

}
