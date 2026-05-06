public class PanelState : IUIState
{
    private PanelView _view;
    private MainView _mainView;
    private Score _score;
    private IService _services;
    private UiSwitcher _switcher;
    private MainState _mainState;

    public PanelState(PanelView view, MainView mainView, Score score, IService services, UiSwitcher switcher)
    {
        _view = view;
        _mainView = mainView;
        _score = score;
        _services = services;
        _switcher = switcher;
    }

    public void SetMainState(MainState mainState)
    {
        _mainState = mainState;
    }

    public void Enter()
    {
        _mainView.SetInteractable(false);

        _view.gameObject.SetActive(true);

        _view.SubscribeClose(Close);
        _view.SubscribeCollect(Collect);

        _services.GetService<ISoundPlayer>().PlayOpenSound();
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
        _services.GetService<ISoundPlayer>().PlayCloseSound();
        _services.GetService<ISaver>().SaveScore(_score.Value);

        _switcher.Switch(_mainState);
    }
}