using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;
using System;
using Random = UnityEngine.Random;

// TODO: Вынести сущность ответственную за размер 
public class ElectroCube : MonoBehaviour
{
    // TODO: Заменить на список
    private PartOfElectroCube[] _partsOfElectroCubes;
    private ElectroCubeStateMachine _stateMachine;

    public Action ExpandedEvent;
    public Action ShrinkedEvent;
    
    public bool IsPlayerCloseEnoughToAttack { private set; get; }

    private void Start()
    {
        _stateMachine = new ElectroCubeStateMachine();
        _stateMachine.Initialize(this);
        _stateMachine.SetPatrolState();

        _partsOfElectroCubes = GetComponentsInChildren<PartOfElectroCube>();
        InitializeOfPartCubes();
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    private void InitializeOfPartCubes()
    {
        for(int i = 0; i < _partsOfElectroCubes.Length; i++)
        {
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

    public Transform FindAvailablePatrolPoint()
    {
        GameObject[] patrolPoints = GameObject.FindGameObjectsWithTag("PatrolPoint");

        GameObject[] nearbyFacitities = Physics.OverlapSphere(transform.position, 16f)
            .Where(nf => nf.CompareTag("PatrolPoint"))
            .Select(nf => nf.gameObject)
            .ToArray();

        Transform[] availablePatrolPoints = patrolPoints
            .Except(nearbyFacitities)
            .Select(pp => pp.transform)
            .ToArray();

        return availablePatrolPoints[Random.Range(0, availablePatrolPoints.Length - 1)];
    }

    public void ExpandInSize()
    {
        StartCoroutine(ExpandInSizeCoroutine());
    }

    private IEnumerator ExpandInSizeCoroutine()
    {
        float timeToExpand = 1f;
        for (int i = 0; i < _partsOfElectroCubes.Length; i++)
        {
            PartOfElectroCube partOfElectroCube = _partsOfElectroCubes[i];
            Vector3 dirToExpand = partOfElectroCube.transform.position - transform.position;
            dirToExpand = dirToExpand.normalized * 5;
            partOfElectroCube.transform.DOMove(partOfElectroCube.transform.position + dirToExpand, timeToExpand);
        }

        yield return new WaitForSeconds(timeToExpand);
        ExpandedEvent?.Invoke();
    }

    public void ShrinkInSize()
    {
        StartCoroutine(ShrinkInSizeCoroutine());
    }

    private IEnumerator ShrinkInSizeCoroutine()
    {
        float timeToShrink = 1f;
        for (int i = 0; i < _partsOfElectroCubes.Length; i++)
        {
            PartOfElectroCube partOfElectroCube = _partsOfElectroCubes[i];
            Vector3 dirToExpand = partOfElectroCube.transform.position - transform.position;
            dirToExpand = dirToExpand.normalized * 5;
            partOfElectroCube.transform.DOMove(partOfElectroCube.transform.position - dirToExpand, timeToShrink);
        }

        yield return new WaitForSeconds(timeToShrink);
        ShrinkedEvent?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            IsPlayerCloseEnoughToAttack = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            IsPlayerCloseEnoughToAttack = false;
    }
}
