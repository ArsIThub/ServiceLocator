using Zenject;

public class GameStarter : IInitializable
{
    private UiSwitcher _switcher;
    private MainState _mainState;

    [Inject]
    public void Construct(UiSwitcher switcher, MainState mainState)
    {
        _switcher = switcher;
        _mainState = mainState;
    }

    public void Initialize()
    {
        _switcher.Switch(_mainState);
    }
}