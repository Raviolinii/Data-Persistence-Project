using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataPersistence : MonoBehaviour
{
    public static DataPersistence Instance;
    private string nick = "";
    private int highScore = -1;
    private string bestPlayerName = "";

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        LoadHighScore();
    }
    public static void SetPlayerName(string name) => Instance.nick = name;
    public static string GetNick() => Instance.nick;
    public static void SetHighScore(int value) => Instance.highScore = value;
    public static int GetHighScore() => Instance.highScore;
    public static void SetBestPlayerName(string name) => Instance.bestPlayerName = name;
    public static string GetBestPlayerName() => Instance.bestPlayerName;


    [System.Serializable]
    class SaveData
    {
        public string nick;
        public int score;
    }

    public void SaveScore(int score)
    {
        SaveData save = new SaveData();
        save.nick = nick;
        save.score = score;
        string json = JsonUtility.ToJson(save);
        File.WriteAllText(Application.persistentDataPath + "/SaveFile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/SaveFile.json";

        if (!File.Exists(path))
            return;

        string json = File.ReadAllText(path);
        SaveData save = new SaveData();
        save = JsonUtility.FromJson<SaveData>(json);
        DataPersistence.SetHighScore(save.score);
        DataPersistence.SetBestPlayerName(save.nick);
    }
}
