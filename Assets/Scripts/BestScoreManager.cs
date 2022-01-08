using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BestScoreManager : MonoBehaviour
{
    public static BestScoreManager Instance;

    public string PlayerName;
    public int HighScore;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(Instance);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestScore();
    }

    public void Fetch(string playerName, int highScore)
    {
        PlayerName = playerName;
        HighScore = highScore;
    }

    [System.Serializable]
    class SaveData
    {
        public SaveData() {}

        public SaveData(string playerName, int highScore)
        {
            PlayerName = playerName;
            HighScore = highScore;
        }

        public string PlayerName;
        public int HighScore;

        public void Fetch(BestScoreManager gameManager)
        {
            gameManager.PlayerName = PlayerName;
            gameManager.HighScore = HighScore;
        }
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData(PlayerName, HighScore);
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            data.Fetch(this);
        }
    }
}
