using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsGun : BaseWeapon
{
    private void Start()
    {
        _playerReadInput.StartShotEvent += Shot;
    }

    public override void Shot()
    {
        var bullet = Instantiate(_bulletPrefab);
        bullet.transform.position = _startBulletPoint.transform.position;
        bullet.transform.rotation = _startBulletPoint.transform.rotation;
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * _v0ForBullet;
    }
}
