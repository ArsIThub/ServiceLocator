using Zenject;

public class MainState : IUIState
{
    private MainView _view;
    private UiSwitcher _switcher;
    private PanelState _panelState;

    [Inject]
    public void Construct(MainView view,UiSwitcher switcher,PanelState panelState)
    {
        _view = view;
        _switcher = switcher;
        _panelState = panelState;
    }

    public void Enter()
    {
        _view.SubscribeOpen(OpenPanel);
        _view.SetInteractable(true);
    }

    public void Exit()
    {
        _view.UnsubscribeOpen(OpenPanel);
    }

    private void OpenPanel()
    {
        _switcher.Switch(_panelState);
    }
}