//using UnityEditor.Overlays;
using UnityEngine;
using System.IO;

public class PersistManager : MonoBehaviour
{
    public static PersistManager persistManager { get; private set; }

    public string playerName;
    public string topScorerName;
    public int playerScore = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(persistManager != null)
        {
            Destroy(gameObject);
            return;
        }

        persistManager = this;
        DontDestroyOnLoad(gameObject); 
    }

    [System.Serializable]
    class PlayerInfo
    {
        public string scorerName = "";
        public int topScore = 0;
    }

    public void SaveScore()
    {
        PlayerInfo data = new PlayerInfo();
        data.scorerName = topScorerName;
        data.topScore = playerScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerInfo data = JsonUtility.FromJson<PlayerInfo>(json);

            topScorerName = data.scorerName;
            playerScore = data.topScore;
        }
    }
}
