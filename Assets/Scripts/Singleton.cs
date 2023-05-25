using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Singleton : MonoBehaviour
{
    public static Singleton Instance;
    public string playerName;
    public int highScore;
    public string currentPlayer;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;

        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadInfo();
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highscore;
    }
    public void SaveInfo()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highscore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            highScore = data.highscore;
        }
    }



}
