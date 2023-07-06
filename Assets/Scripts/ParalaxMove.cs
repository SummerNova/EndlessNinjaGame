using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(PlayerPrefs.GetFloat("Speed")*Time.deltaTime*(-0.2f),0,0));
        if (transform.position.x<-57.5f){
            transform.Translate(new Vector3(115,0,0));
        }
    }
}
