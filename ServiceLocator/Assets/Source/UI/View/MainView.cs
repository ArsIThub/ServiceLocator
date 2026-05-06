using System;
using UnityEngine;
using UnityEngine.UI;

public class MainView : MonoBehaviour
{
    [SerializeField] private Button openButton;

    public void SubscribeOpen(Action action)
    {
        openButton.onClick.AddListener(() => action());
    }

    public void UnsubscribeOpen(Action action)
    {
        openButton.onClick.RemoveListener(() => action());
    }

    public void SetInteractable(bool value)
    {
        openButton.interactable = value;
    }
}