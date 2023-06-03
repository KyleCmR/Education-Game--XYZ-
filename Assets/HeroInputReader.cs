using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class HeroInputReader : MonoBehaviour
{
    [SerializeField] private Hero _hero;
    private HeroInputAction _inputActions;

    private void Awake()
    {
        _inputActions = new HeroInputAction();
        _inputActions.Hero.Movement.performed += OnMovement;
        _inputActions.Hero.Movement.canceled += OnMovement;
    }
    private void OnEnable()
    {
        _inputActions.Enable();
    }
    private void OnMovement(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<float>();
        _hero.SetDirection(direction);
    }


}
