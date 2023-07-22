using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Rename - не манипулятор, а положение руки
public class ManipulatorPosition : MonoBehaviour
{
    [SerializeField] private BezierCurve _bezierCurve;
    [SerializeField] private float _speedMovement = 0.2f;
    [SerializeField] private Transform _manipulatorPoint;

    private const float EPS = 0.01f;

    public Action ReachedLoadingPoint;
    public Action ReachedUnloadingPoint;

    public void MoveToLoadingPoint()
    {
        StartCoroutine(MoveToLoadingPointCoroutine());
    }

    public void MoveToUnoadingPoint()
    {
        StartCoroutine(MoveToUnloadingPointCoroutine());
    }

    private IEnumerator MoveToLoadingPointCoroutine()
    {
        float t = 0;
        while(t < 1 - EPS)
        {
            t += Time.deltaTime * _speedMovement;
            _manipulatorPoint.position = _bezierCurve.GetPointAt(t);
            yield return new WaitForEndOfFrame();
        }

        ReachedLoadingPoint?.Invoke();
    }

    private IEnumerator MoveToUnloadingPointCoroutine()
    {
        float t = 1 - EPS;
        while (t > EPS)
        {
            t -= Time.deltaTime * _speedMovement;
            _manipulatorPoint.position = _bezierCurve.GetPointAt(t);
            yield return new WaitForEndOfFrame();
        }

        ReachedUnloadingPoint?.Invoke();
    }
}
