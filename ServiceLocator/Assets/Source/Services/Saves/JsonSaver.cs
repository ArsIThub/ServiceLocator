using System.IO;
using UnityEngine;

[System.Serializable]
public class ScoreData
{
    public int score;
}

public class JsonSaver : ISaver
{
    public void SaveScore(int score, string path = null)
    {
        var data = new ScoreData { score = score };
        var json = JsonUtility.ToJson(data);

        File.WriteAllText(path, json);
    }
}