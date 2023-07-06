using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public List<GameObject> platformRef = new List<GameObject>();
    GameObject newPlatform;

    // Start is called before the first frame update
    void Start()
    {
        newPlatform = Instantiate(platformRef[0], new Vector3(0,07 ,20), Quaternion.identity);
        newPlatform.transform.parent = gameObject.transform;

        for (int i = 0; i<2;i++){
            newPlatform = Instantiate(platformRef[1], new Vector3(0+i*57.5f,-1 ,15), Quaternion.identity);
            newPlatform.transform.parent = gameObject.transform;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col){
        
    }


}
