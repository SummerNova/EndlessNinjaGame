using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PlatformLoader : MonoBehaviour
{
    public List<GameObject> platformRef = new List<GameObject>();
    Random rng = new Random();
    public float acceleration;
    public float speed;
    GameObject newPlatform;
    GameObject lastPlaform;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i<7;i++){

            newPlatform = Instantiate(platformRef[0], new Vector3(-30+ 10*i,-3+(float)System.Math.Pow(-1,i)*i/10f ,0), Quaternion.identity);
            newPlatform.transform.parent = gameObject.transform;
        }
        lastPlaform = newPlatform;
        PlayerPrefs.SetInt("CurrentRunScore",0);
        PlayerPrefs.SetFloat("Speed",speed);
    }

    // Update is called once per frame
    void Update()
    {
        speed += Time.deltaTime*acceleration;
        PlayerPrefs.SetFloat("Speed",speed);
    }

    void OnCollisionEnter2D(Collision2D col){
        if (transform.childCount<13){
            lastPlaform = newPlatform;
            newPlatform = Instantiate(platformRef[rng.Next(0,6)], new Vector3(lastPlaform.transform.position.x+7+speed*1.3f,NextFloat(-2f, -4f) ,0), Quaternion.identity);
            newPlatform.transform.parent = gameObject.transform;
        }
        
    }

    static float NextFloat(float min, float max){
        System.Random random = new System.Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }
}
