using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    public string playerName;
    public int highscore;
    
    public static SaveData Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        LoadName();
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveD
    {
        public string playerName;
        public int highscore;
    }

    public void SaveName()
    {
        SaveD data = new SaveD();
        data.playerName = playerName;
        data.highscore = highscore;

        string json = JsonUtility.ToJson(data);
  
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveD data = JsonUtility.FromJson<SaveD>(json);

            playerName = data.playerName;
            highscore = data.highscore;
        }
    }

    public void SwitchScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}