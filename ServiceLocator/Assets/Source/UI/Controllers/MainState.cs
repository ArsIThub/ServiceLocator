public class MainState : IUIState
{
    private MainView _view;
    private UiSwitcher _switcher;
    private PanelState _panelState;

    public MainState(MainView view, UiSwitcher switcher, PanelState panelState)
    {
        _view = view;
        _switcher = switcher;
        _panelState = panelState;
    }

    public void Enter()
    {
        _view.SubscribeOpen(Open);
        _view.SetInteractable(true);
    }

    public void Exit()
    {
        _view.UnsubscribeOpen(Open);
    }

    private void Open()
    {
        _switcher.Switch(_panelState);
    }
}