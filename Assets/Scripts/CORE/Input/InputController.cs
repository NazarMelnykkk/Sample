using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public static InputController Instance;


    public static CharacterInputActions InputActions;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        InputActions = new CharacterInputActions();
        InputActions.Enable();
    }

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

}
