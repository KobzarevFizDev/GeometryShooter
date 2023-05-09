using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TestTarget : MonoBehaviour
{
    [SerializeField] private GameObject _destroyedTarget;
    [SerializeField] private GameObject _solidTarget;

    private GameObject[] _cells;
    private Rigidbody[] _cellsRG;
    private void Start()
    {
        _cellsRG = _destroyedTarget.GetComponentsInChildren<Rigidbody>();
        _cells = _cellsRG.Select(c => c.gameObject).ToArray();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Bullet"))
            DestroyTarget();
    }

    private void DestroyTarget()
    {
        _solidTarget.SetActive(false);
        _destroyedTarget.SetActive(true);
        foreach(Rigidbody rg in _cellsRG)
            rg.isKinematic = false;

        StartCoroutine(ClearCellsCoroutine());
    }

    private IEnumerator ClearCellsCoroutine()
    {
        yield return new WaitForSeconds(4f);
        foreach(var cell in _cells)
        {
            Destroy(cell.gameObject);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
