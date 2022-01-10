using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class BestScoreManager : MonoBehaviour
{
    public static BestScoreManager Instance;

    public List<string> PlayerNames;
    public List<int> HighScores;

    public int MaxSaveNum = 10;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(Instance);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        Init();
        LoadBestScore();
    }

    public void Init()
    {
        PlayerNames = new string[MaxSaveNum].ToList();
        HighScores = new int[MaxSaveNum].ToList();
    }

    public void Fetch(string playerName, int highScore)
    {
        for (int i = MaxSaveNum - 1; i > -1; i--)
        {
            if (highScore > HighScores[i])
            {
                continue;
            }
            else
            {
                PlayerNames.Insert(i + 1, playerName);
                HighScores.Insert(i + 1, highScore);
                Remove();

                return;
            }
        }

        PlayerNames.Insert(0, playerName);
        HighScores.Insert(0, highScore);
        Remove();
    }

    private void Remove()
    {
        PlayerNames.RemoveRange(MaxSaveNum, PlayerNames.Count - MaxSaveNum);
        HighScores.RemoveRange(MaxSaveNum, HighScores.Count - MaxSaveNum);
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
    }

    [System.Serializable]
    class SaveDataBase
    {
        public SaveDataBase() { DB = new List<SaveData>(); }

        public SaveDataBase(List<string> playerNames, List<int> highScores)
        {
            DB = new SaveData[playerNames.Count].ToList();
            for (int i = 0; i < playerNames.Count; i++)
            {
                DB[i] = new SaveData(playerNames[i], highScores[i]);
            }
        }

        public List<SaveData> DB;

        public void Fetch(BestScoreManager manager)
        {
            for (int i = 0; i < DB.Count; i++)
            {
                manager.PlayerNames[i] = DB[i].PlayerName;
                manager.HighScores[i] = DB[i].HighScore;
            }
        }
    }

    public void SaveBestScore()
    {
        SaveDataBase db = new SaveDataBase(PlayerNames, HighScores);
        string json = JsonUtility.ToJson(db);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveDataBase db = JsonUtility.FromJson<SaveDataBase>(json);

            db.Fetch(this);
        }
    }
}
