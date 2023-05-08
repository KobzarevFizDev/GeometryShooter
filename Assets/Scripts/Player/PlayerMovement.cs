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

    [Header("Jump settings")]
    [SerializeField] private float _heightOfJump = 3f;

    [Header("Gravity settings")]
    [SerializeField] private float _gravity = -9.81f;

    private CharacterController _characterController;
    private PlayerStateMachine _playerStateMachine;
    private PlayerReadInput _playerReadInput;

    private float _yVelocity;

    private float _currentHitDistance;
    private GameObject _groundGO;

    public float YVelocity => _yVelocity;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerStateMachine = new PlayerStateMachine();

        _playerReadInput = new PlayerReadInput();
    }

    private void Start()
    {
        _playerStateMachine.Initialize(this, _characterController, _playerReadInput);
        _playerStateMachine.SetIdleState();
    }

    private void Update()
    {
        _playerStateMachine.Update();

        if (IsGrounded())
            _yVelocity = -2f;

        DoGravity();
    }

    public void MoveForward(float horizontal, float vertical)
    {
        Vector3 moveDirection = transform.forward * vertical + transform.right * horizontal;
        Vector3 moveVector = moveDirection * _speedOfMovement * Time.deltaTime;
        _characterController.Move(moveVector);
    }

    public bool IsGrounded()
    {
        RaycastHit hitInfo;
        Ray ray = new Ray(_groundCheckerPivot.transform.position, -Vector3.up);
        if (Physics.SphereCast(ray, _radiusOfGroundSphereRaycast, out hitInfo, _lengthOfRaycast, _groundRaycastMask))
        {
            _currentHitDistance = hitInfo.distance;
            _groundGO = hitInfo.transform.gameObject;
            return true;
        }
        else
        {
            _groundGO = null;
            return false;
        }
    }

    public void Jump()
    {
        _yVelocity = Mathf.Sqrt(_heightOfJump * -2 * _gravity);
    }

    private void DoGravity()
    {
        _yVelocity += _gravity * Time.deltaTime;
        _characterController.Move(Vector3.up * _yVelocity);
    }

    private void OnDrawGizmos()
    {
        if(_groundGO != null)
            Gizmos.color = Color.green;
        Debug.DrawLine(_groundCheckerPivot.transform.position, _groundCheckerPivot.transform.position + -Vector3.up * _currentHitDistance);
        Gizmos.DrawWireSphere(_groundCheckerPivot.transform.position + -Vector3.up * _currentHitDistance, _radiusOfGroundSphereRaycast);
    }
}
