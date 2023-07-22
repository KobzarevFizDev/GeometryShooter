using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManupulatorTest : MonoBehaviour
{
    [SerializeField] private float _movementDuration = 5f;
    [SerializeField] private float _delay = 2f;
    [SerializeField] private Transform _manipulatorControllerPoint;
    [SerializeField] private BezierCurve _bezierCurve;

    private bool _forward = false;

    private void Start()
    {
        StartCoroutine(ForwardMovement());
    }

    public IEnumerator ForwardMovement()
    {
        yield return new WaitForSeconds(_delay);
        float t = 0;
        while (t < 0.95f)
        {
            t += Time.deltaTime / _movementDuration;
            _manipulatorControllerPoint.position = _bezierCurve.GetPointAt(t);
            print($"t= {t}, {_manipulatorControllerPoint.position}");
            yield return new WaitForEndOfFrame();
        }
    }
}
