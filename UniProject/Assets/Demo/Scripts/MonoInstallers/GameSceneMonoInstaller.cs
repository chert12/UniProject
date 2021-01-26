using UniProject.Demo;
using UnityEngine;
using Zenject;

public class GameSceneMonoInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<GameService>().AsSingle();
    }
}