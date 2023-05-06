using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Raycast settings")]
    [SerializeField] private Transform _groundCheckerPivot;
    [SerializeField] private float _radiusOfGroundSphereRaycast = 1;
    [SerializeField] private float _lengthOfRaycast = 1;
    [SerializeField] private LayerMask _groundRaycastMask;

    [Header("Movement settings")]
    [SerializeField] private float _speedOfMovement = 2f;
    [SerializeField] private float _speedOfRotate = 3f;

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

        IsGrounded();
    }

    public void MoveForward(float horizontal, float vertical)
    {
        Vector3 moveDirection = transform.forward * vertical + transform.right * horizontal;
        Vector3 projectOfMoveDirectionOnNormalOfGround = moveDirection - Vector3.Dot(moveDirection, NormalOfGround) * NormalOfGround;
        Vector3 moveVector = projectOfMoveDirectionOnNormalOfGround * _speedOfMovement * Time.deltaTime;
        _characterController.Move(moveVector);
    }

    public bool IsGrounded()
    {
        RaycastHit hitInfo;
        Ray ray = new Ray(_groundCheckerPivot.transform.position, -Vector3.up);
        if (Physics.SphereCast(ray, _radiusOfGroundSphereRaycast, out hitInfo, _lengthOfRaycast, _groundRaycastMask))
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_groundCheckerPivot.transform.position, _radiusOfGroundSphereRaycast);
    }
}
