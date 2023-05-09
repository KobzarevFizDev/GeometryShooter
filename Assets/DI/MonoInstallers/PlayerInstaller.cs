using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        PlayerReadInput playerReadInput = new PlayerReadInput();
        Container.Bind<PlayerReadInput>().FromInstance(playerReadInput).AsSingle().NonLazy();
    }
}
