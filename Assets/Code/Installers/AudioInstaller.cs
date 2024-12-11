using UnityEngine;
using Zenject;

public class AudioInstaller : MonoInstaller
{
    [SerializeField] private AudioController _audioController;
    public override void InstallBindings()
    {
        Container.Bind<AudioController>().FromInstance(_audioController).AsSingle();
    }
}