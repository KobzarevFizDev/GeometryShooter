using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Raycast settings")]
    [SerializeField] private Transform _groundCheckerPivot;
    [SerializeField] private float _radiusOfGroundSphereRaycast;
    [SerializeField] private LayerMask _groundRaycastMask;

    [Header("Movement settings")]
    [SerializeField] private float _speedOfMovement = 2f;

    private CharacterController _characterController;
    private PlayerStateMachine _playerStateMachine;
    private PlayerInputActions _playerInputActions;

    public Vector3 NormalOfGround { private set; get; }

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

    public void MoveToDirection(Vector3 moveDirection)
    {
        Vector3 projectOfMoveDirectionOnNormalOfGround = moveDirection - Vector3.Dot(moveDirection, NormalOfGround) * NormalOfGround;
        Vector3 moveVector = projectOfMoveDirectionOnNormalOfGround * _speedOfMovement;
        _characterController.Move(moveVector);
    }

    public bool IsGrounded()
    {
        RaycastHit hitInfo;
        if (Physics.SphereCast(_groundCheckerPivot.transform.position, _radiusOfGroundSphereRaycast, -Vector3.up, out hitInfo, _groundRaycastMask))
        {
            NormalOfGround = hitInfo.normal;
            return true;
        }
        else
        {
            NormalOfGround = Vector3.zero;
            return false;
        }
    }
}
