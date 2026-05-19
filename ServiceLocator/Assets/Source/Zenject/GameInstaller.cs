using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private MainView mainView;
    [SerializeField] private PanelView panelView;
    [Space]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip openClip;
    [SerializeField] private AudioClip closeClip;

    public override void InstallBindings()
    {
        Container.Bind<MainView>().FromInstance(mainView).AsSingle();
        Container.Bind<PanelView>().FromInstance(panelView).AsSingle();
        Container.Bind<AudioSource>().FromInstance(audioSource).AsSingle();
        Container.Bind<AudioClip>().WithId("OpenClip").FromInstance(openClip);
        Container.Bind<AudioClip>().WithId("CloseClip").FromInstance(closeClip);
        Container.Bind<IFadeService>().To<FadeService>().AsSingle();
        Container.Bind<ISoundPlayer>().To<SoundPlayer>().AsSingle().NonLazy();
        Container.Bind<ISaver>().To<PlayerPrefsSaver>().AsSingle();
        Container.Bind<Score>().AsSingle();
        Container.Bind<UiSwitcher>().AsSingle();
        Container.Bind<MainState>().AsSingle();
        Container.Bind<PanelState>().AsSingle();

        Container.BindInterfacesAndSelfTo<GameStarter>().AsSingle().NonLazy();
    }
}
