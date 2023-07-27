using UnityEngine;
using UnityEngine.Animations;

public class ClampManipulator : MonoBehaviour
{
    [SerializeField] private Transform _leftRetainer;
    [SerializeField] private Transform _rightRetainer;
    [SerializeField] private Transform _spawnCargoPoint;
    [SerializeField] private GameObject _cargoPrefab;

    private ParentConstraint _cargoConstraint;
    private GameObject _cargo;

    public void TakeCargo()
    {
        _cargo = Instantiate(_cargoPrefab);
        _cargo.transform.position = transform.position;

        _cargoConstraint = _cargo.AddComponent<ParentConstraint>();
        ConstraintSource constraintSource = new ConstraintSource();
        constraintSource.weight = 1f;
        constraintSource.sourceTransform = _spawnCargoPoint;
        _cargoConstraint.AddSource(constraintSource);
        _cargoConstraint.constraintActive = true;
    }

    public void ReleaseCargo()
    {
        Destroy(_cargoConstraint);
    }
}
