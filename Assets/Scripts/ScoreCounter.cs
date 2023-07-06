using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreCounter : MonoBehaviour
{
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("CurrentRunScore")){
            text.text = "Score:\n" + PlayerPrefs.GetInt("CurrentRunScore");
        }
        
    }
}
