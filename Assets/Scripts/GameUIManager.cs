using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isPaused = false;
    public GameObject pausePanel;
    public GameObject deathPanel;
    public GameObject leaderboardPanel;
    public PlayerManager player;
    public TMP_Text text; 
    public TMP_Text RunName;
    public TMP_Text scores;
    private bool notDeadYet = true;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            TogglePause();
        }

        if (player.player != null && player.player.transform.position.y < -12f && notDeadYet){
            Time.timeScale = 0f;
            deathPanel.SetActive(true);
            text.text = "You Died\nYour Score is:" + PlayerPrefs.GetInt("CurrentRunScore");
            notDeadYet = false;

        }
    }

    public void TogglePause(){
        if (isPaused){
            Time.timeScale = 1.0f;
            isPaused = false;
            pausePanel.SetActive(false);
        }
        else{
            Time.timeScale = 0f;
            isPaused = true;
            pausePanel.SetActive(true);
        }
    }

    public void Restart(){
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu(){
        Time.timeScale = 1.0f;
        PlayerPrefs.SetInt("CurrentRunScore",0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Main Menu");
    }

    public void SaveScore(){
        Leaderboard.Record(RunName.text, PlayerPrefs.GetInt("CurrentRunScore"));
    }

    public void toggleLeaderboard(){
        deathPanel.SetActive(false);
        leaderboardPanel.SetActive(true);
        scores.text = "";
        for (int i = 0; i < Leaderboard.EntryCount; ++i) {
            var entry = Leaderboard.GetEntry(i);
            if (entry.name != ""){
                scores.text += entry.name + " - " + entry.score + "\n";
            }
        }

    }


}
