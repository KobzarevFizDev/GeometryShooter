using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class BaseWeapon : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] protected GameObject _bulletPrefab;
    [SerializeField] protected Transform _startBulletPoint;
    [SerializeField] protected float _delayBetweenShot = 1;
    [SerializeField] protected float _damageValue;
    [SerializeField] protected float _v0ForBullet;

    protected PlayerReadInput _playerReadInput;

    [Inject]
    public void Inject(PlayerReadInput playerReadInput)
    {
        _playerReadInput = playerReadInput;
    }

    public abstract void Shot();
}
