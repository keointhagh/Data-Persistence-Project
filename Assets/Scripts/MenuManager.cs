using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputNameEntered;

    public Text ScoreNameText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PersistManager.persistManager.LoadScore();
        ScoreNameText.text = "Best Score : " + PersistManager.persistManager.topScorerName + " : " + PersistManager.persistManager.playerScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        //Debug.Log("Game is starting");
        SceneManager.LoadScene(1);
    }

    public void InputNameField()
    {
        string nameIn = inputNameEntered.text;
        if (nameIn.Length == 0 || nameIn  == null) nameIn = "Bob";
        PersistManager.persistManager.playerName = nameIn;
        //Debug.Log("Input entered is: " + PersistManager.persistManager.playerName);
    }
}
