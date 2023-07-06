using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject leaderboardPanel;
    public TMP_Text scores;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Game");
    }

    public void ScoreBoard(){
        mainPanel.SetActive(false);
        leaderboardPanel.SetActive(true);
        scores.text = "";
        for (int i = 0; i < Leaderboard.EntryCount; ++i) {
            var entry = Leaderboard.GetEntry(i);
            if (entry.name != ""){
                scores.text += entry.name + " - " + entry.score + "\n";
            }
        }
    }

    public void QuitGame(){
        PlayerPrefs.Save();
        Application.Quit();
    }

    public void mainMenu(){
        mainPanel.SetActive(true);
        leaderboardPanel.SetActive(false);
    }
}
