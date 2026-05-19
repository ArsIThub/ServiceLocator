using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class PanelView : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    [SerializeField] private Button collectButton;
    [SerializeField] private TextMeshProUGUI scoreText;
    [Space]
    [SerializeField] private Image panelImage;

    public Image PanelImage => panelImage;

    public void SubscribeClose(UnityAction action)
    {
        closeButton.onClick.AddListener(action);
    }

    public void UnsubscribeClose(UnityAction action)
    {
        closeButton.onClick.RemoveListener(action);
    }

    public void SubscribeCollect(UnityAction action)
    {
        collectButton.onClick.AddListener(action);
    }

    public void UnsubscribeCollect(UnityAction action)
    {
        collectButton.onClick.RemoveListener(action);
    }

    public void SetScore(int value)
    {
        scoreText.text = value.ToString();
    }
}