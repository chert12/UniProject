using UniProject.Demo;
using UnityEngine;
using Zenject;

public class MenuSceneMonoInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<MenuService>().AsSingle();
    }
}