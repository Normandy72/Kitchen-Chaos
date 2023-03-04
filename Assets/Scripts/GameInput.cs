using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set;} 

    public event EventHandler OnInteractionAction;
    public event EventHandler OnInteractionAlternateAction;
    public event EventHandler OnPauseAction;
    private PlayerInputActions playerInputActions;
    private void Awake()
    {
        Instance = this;

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interact_perfomed;
        playerInputActions.Player.InteractAlternate.performed += InteractAlternate_perfomed;
        playerInputActions.Player.Pause.performed += Pause_perfomed;
    }

    private void Interact_perfomed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractionAction ? .Invoke(this, EventArgs.Empty);       
    }

    private void InteractAlternate_perfomed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractionAlternateAction? .Invoke(this, EventArgs.Empty);
    }

    private void Pause_perfomed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPauseAction? .Invoke(this, EventArgs.Empty);
    }

   public Vector2 GetMovementVectorNormalized()
   {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        
        inputVector = inputVector.normalized;

        return inputVector;
   }
}
