using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FixedJoint))]
public class ClampManipulator : MonoBehaviour
{
    [SerializeField] private Transform _leftRetainer;
    [SerializeField] private Transform _rightRetainer;
    [SerializeField] private Transform _spawnCargoPoint;
    [SerializeField] private GameObject _cargoPrefab;

    private GameObject _cargo;

    private FixedJoint _fixedJoint;

    private void Start()
    {
        _fixedJoint = GetComponent<FixedJoint>();
    }

    public void TakeCargo()
    {
        _cargo = Instantiate(_cargoPrefab);
        _cargo.transform.position = transform.position;
        var cargoRG = _cargo.GetComponent<Rigidbody>();
        _fixedJoint.connectedBody = cargoRG;
        cargoRG.isKinematic = false;
        cargoRG.useGravity = false;
    }

    public void ReleaseCargo()
    {
        if (null == _cargo)
            return;

        var cargoRG = _cargo.GetComponent<Rigidbody>();
        _fixedJoint.connectedBody = null;
        cargoRG.isKinematic = false;
        cargoRG.useGravity = true;
    }
}
