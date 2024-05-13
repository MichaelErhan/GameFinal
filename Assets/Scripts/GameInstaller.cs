using Netologia.Necro;
using Netologia.Necro.Manager;
using UnityEngine;
using Zenject;
public class GameInstaller : MonoInstaller
{
    private Controls _controls;
    [SerializeField] private SceneController _controller;

    public override void InstallBindings()
    {
        _controls = new Controls();
        _controls.Game.Enable();
        
        Container.BindInstance(_controls.Game).AsSingle();
        Container.BindInstance(_controller).AsSingle();
    }

    private void OnDestroy()
    {
        _controls.Dispose();
    }
} 