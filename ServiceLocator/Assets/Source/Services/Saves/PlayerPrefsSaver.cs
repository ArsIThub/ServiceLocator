using UnityEngine;

public class PlayerPrefsSaver : ISaver
{
    public void SaveScore(int score, string path = null)
    {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.Save();
    }
}