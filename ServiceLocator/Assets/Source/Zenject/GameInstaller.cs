using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private MainView mainView;
    [SerializeField] private PanelView panelView;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip openClip;
    [SerializeField] private AudioClip closeClip;
    [Space]
    [SerializeField] private PlayerData playerData;
    [SerializeField] private InputListener inputListener;
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] TargetData targetData;

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

        Container.Bind<PlayerData>().FromInstance(playerData).AsSingle();
        Container.Bind<InputListener>().FromInstance(inputListener).AsSingle().NonLazy();
        Container.Bind<PlayerMovement>().AsSingle();
        Container.Bind<PlayerShooting>().AsSingle();
        Container.Bind<Invoker>().AsSingle();
        Container.Bind<TargetData>().FromInstance(targetData).AsSingle();
        Container.BindFactory<Bullet, Bullet.Factory>().FromComponentInNewPrefab(bulletPrefab);
        Container.Bind<BulletPool>().AsSingle().NonLazy();

        Container.BindInterfacesAndSelfTo<GameStarter>().AsSingle().NonLazy();
    }
}
