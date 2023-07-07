using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{ 
    public PlatformLoader platLoad;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        platLoad = gameObject.transform.parent.GetComponent<PlatformLoader>();
    }

    // Update is called once per frame
    void Update()
    {   
        speed = platLoad.speed;

        transform.Translate((new Vector3(-1*speed, 0,0))*Time.deltaTime);

        if (transform.position.x < -50){
            platLoad.POP(gameObject);
        }
    }
}
