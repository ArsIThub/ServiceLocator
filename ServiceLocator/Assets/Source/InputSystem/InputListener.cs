using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class InputListener : MonoBehaviour
{
    private MainInputActions _mainInputActions;
    private Invoker _invoker;
    private Vector2 _inputValue;

    [Inject]
    public void Construct(Invoker invoker) 
    {
        _invoker = invoker;
    }

    private void Awake()
    {
        _mainInputActions = new();
        Bind();
        _mainInputActions.Enable();
    }

    private void FixedUpdate()
    {
        _invoker.InvokeMove(_inputValue);
    }

    private void OnMovement(InputAction.CallbackContext context)
    {
        _inputValue = context.ReadValue<Vector2>();
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        _invoker.InvokeShoot();
    }

    private void Bind() 
    {
        _mainInputActions.Game.Move.performed += OnMovement;
        _mainInputActions.Game.Shoot.performed += OnShoot;
    }
    private void Expose()
    {
        _mainInputActions.Game.Move.performed += OnMovement;
        _mainInputActions.Game.Shoot.performed += OnShoot;
    }

    private void OnDestroy()
    {
        _mainInputActions.Disable();
        Expose();
    }
}
