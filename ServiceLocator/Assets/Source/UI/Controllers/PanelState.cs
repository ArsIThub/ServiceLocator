using Zenject;

public class PanelState : IUIState
{
    private PanelView _view;
    private MainView _mainView;
    private Score _score;
    private UiSwitcher _switcher;

    private IFadeService _fadeService;
    private ISoundPlayer _soundPlayer;
    private ISaver _saver;

    private MainState _mainState;

    [Inject]
    public void Construct(PanelView view, MainView mainView, Score score, UiSwitcher switcher, 
                        IFadeService fadeService, ISoundPlayer soundPlayer, ISaver saver)
    {
        _view = view;
        _mainView = mainView;
        _score = score;
        _switcher = switcher;

        _fadeService = fadeService;
        _soundPlayer = soundPlayer;
        _saver = saver;
    }

    [Inject]
    public void SetMainState(MainState mainState)
    {
        _mainState = mainState;
    }

    public void Enter()
    {
        _mainView.SetInteractable(false);
        _view.gameObject.SetActive(true);

        _soundPlayer.PlayOpenSound();
        _fadeService.FadeIn(_view.PanelImage, 0.5f);

        _view.SubscribeClose(Close);
        _view.SubscribeCollect(Collect);
    }

    public void Exit()
    {
        _view.UnsubscribeClose(Close);
        _view.UnsubscribeCollect(Collect);

        _view.gameObject.SetActive(false);
    }

    private void Collect()
    {
        _score.Add();

        _view.SetScore(_score.Value);
    }

    private void Close()
    {
        _soundPlayer.PlayCloseSound();
        _fadeService.FadeOut(_view.PanelImage, 0.5f);

        _saver.SaveScore(_score.Value);

        _switcher.Switch(_mainState);
    }
}