using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _groundCheckerPivot;
    [SerializeField] private float _radiusOfGroundSphereRaycast;

    private CharacterController _characterController;
    private PlayerStateMachine _playerStateMachine;
    private PlayerInputActions _playerInputActions;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerStateMachine = new PlayerStateMachine();

        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Enable();
    }

    private void Start()
    {
        _playerStateMachine.Initialize(this, _characterController, _playerInputActions);
        _playerStateMachine.SetIdleState();
    }

    private void Update()
    {
        _playerStateMachine.Update();
    }
}
