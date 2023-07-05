using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isPaused = false;
    public GameObject panel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            TogglePause();
        }
    }

    public void TogglePause(){
        if (isPaused){
            Time.timeScale = 1.0f;
            isPaused = false;
            panel.SetActive(false);
        }
        else{
            Time.timeScale = 0f;
            isPaused = true;
            panel.SetActive(true);
        }
    }

    public void Restart(){
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
