using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private MainView mainView;
    [SerializeField] private PanelView panelView;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip openClip;
    [SerializeField] private AudioClip closeClip;

    private void Start()
    {
        var fade = new FadeService();
        var sound = new SoundPlayer(audioSource, openClip, closeClip);
        var saver = new PlayerPrefsSaver();

        var locator = new ServiceLocator(fade, sound, saver);

        var score = new Score();
        var switcher = new UiSwitcher();

        var panelState = new PanelState(panelView, mainView, score, locator, switcher);

        var mainState = new MainState(mainView, switcher, panelState);

        panelState.SetMainState(mainState);
        switcher.Switch(mainState);
    }
}