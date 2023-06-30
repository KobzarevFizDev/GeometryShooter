using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroCube : MonoBehaviour
{
    private PartOfElectroCube[] _partsOfElectroCubes;

    private void Start()
    {
        _partsOfElectroCubes = GetComponentsInChildren<PartOfElectroCube>();
        InitializeOfPartCubes();
    }

    private void InitializeOfPartCubes()
    {
        for(int i = 0; i < _partsOfElectroCubes.Length; i++)
        {
            _partsOfElectroCubes[i].IdOfPart = i;
            _partsOfElectroCubes[i].HitEvent += OnPartDestroyed; 
        }
    }

    private void OnPartDestroyed(PartOfElectroCube partOfElectroCube)
    {
        Vector3 velocityToDiscard = partOfElectroCube.transform.position - transform.position;
        velocityToDiscard = velocityToDiscard.normalized * 12f;
        partOfElectroCube.DiscardDamagedPart(velocityToDiscard, 4f);
        print($"On hit: {partOfElectroCube.IdOfPart}");
    }
}
