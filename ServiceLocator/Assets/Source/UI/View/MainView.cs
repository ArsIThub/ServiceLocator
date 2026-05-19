using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MainView : MonoBehaviour
{
    [SerializeField] private Button openButton;

    public void SubscribeOpen(UnityAction action)
    {
        openButton.onClick.AddListener(action);
    }

    public void UnsubscribeOpen(UnityAction action)
    {
        openButton.onClick.RemoveListener(action);
    }

    public void SetInteractable(bool value)
    {
        openButton.interactable = value;
    }
}