using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomInputManager : MonoBehaviour
{
    public static CustomInputManager instance;

    MainAction playerInput;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);

        else
            instance = this;

        playerInput = new MainAction();

        playerInput.MainActions.Move.started += OnMoveAction;
        playerInput.MainActions.Move.performed += OnMoveAction;
        playerInput.MainActions.Move.canceled += OnMoveAction;

        playerInput.MainActions.Attack.started += OnAttackAction;
        playerInput.MainActions.Attack.performed += OnAttackAction;
        playerInput.MainActions.Attack.canceled += OnAttackAction;
    }

    private void OnMoveAction(InputAction.CallbackContext context)
    {
        Debug.Log("On MoveAction : " + context.ReadValue<Vector2>());
    }
    private void OnMove(InputValue value)
    {
        Debug.Log("On Move : " + value.Get<Vector2>());
    }

    private void OnAttackAction(InputAction.CallbackContext context)
    {
        Debug.Log("On AttackAction : " + context.ReadValueAsButton());
    }
    private void OnAttack(InputAction.CallbackContext context)
    {
        Debug.Log("On Attack : " + context.ReadValueAsButton());
    }


}
