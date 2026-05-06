public class UiSwitcher
{
    private IUIState _current;

    public void Switch(IUIState state)
    {
        _current?.Exit();
        _current = state;
        _current.Enter();
    }
}