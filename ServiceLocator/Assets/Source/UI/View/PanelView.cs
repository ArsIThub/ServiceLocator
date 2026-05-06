using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelView : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    [SerializeField] private Button collectButton;
    [Space]
    [SerializeField] private TextMeshProUGUI scoreText;

    public void SubscribeClose(Action action)
    {
        closeButton.onClick.AddListener(() => action());
    }

    public void UnsubscribeClose(Action action)
    {
        closeButton.onClick.RemoveListener(() => action());
    }

    public void SubscribeCollect(Action action)
    {
        collectButton.onClick.AddListener(() => action());
    }

    public void UnsubscribeCollect(Action action)
    {
        collectButton.onClick.RemoveListener(() => action());
    }

    public void SetScore(int value)
    {
        scoreText.text = value.ToString();
    }
}