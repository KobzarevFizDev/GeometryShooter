using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PartOfElectroCube : MonoBehaviour
{
    [SerializeField] private GameObject _solidPartOfCube;
    [SerializeField] private GameObject _destroyPartOfCube;

    public Action<PartOfElectroCube> HitEvent;

    public int IdOfPart { get; set; }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            HitEvent?.Invoke(this);
        }

        if (collision.transform.CompareTag("Ground"))
        {
            Explode();
        }
    }

    public void DiscardDamagedPart(Vector3 velocityDiscard, float timeToExplosion)
    {
        print($"discard: {velocityDiscard}");
        var rg = GetComponent<Rigidbody>();
        rg.useGravity = true;
        rg.isKinematic = false;
        rg.velocity = velocityDiscard;
    }

    private void Explode()
    {
        Destroy(_solidPartOfCube);
        _destroyPartOfCube.SetActive(true);
        foreach (var rg in GetComponentsInChildren<Rigidbody>())
        {
            rg.AddExplosionForce(100f, transform.position, 3f);
        }
    }
}
