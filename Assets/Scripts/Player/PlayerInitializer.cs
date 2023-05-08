using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInitializer : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private BaseWeapon _playerWeapon;

    private void Awake()
    {
        PlayerReadInput playerReadInput = new PlayerReadInput();
        _playerMovement.Inject(playerReadInput);
        _playerWeapon.Inject(playerReadInput);
    }
}
