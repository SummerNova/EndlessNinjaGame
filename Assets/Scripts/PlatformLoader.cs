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
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i<7;i++){

            newPlatform = Instantiate(platformRef[0], new Vector3(-30+ 10*i,-3+(float)System.Math.Pow(-1,i)*i/10f ,0), Quaternion.identity);
            newPlatform.transform.parent = gameObject.transform;
        }
        lastPlaform = newPlatform;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        speed += Time.deltaTime*acceleration;
    }

    void OnCollisionEnter2D(Collision2D col){
        lastPlaform = newPlatform;
        newPlatform = Instantiate(platformRef[rng.Next(0,5)], new Vector3(lastPlaform.transform.position.x+7+speed,NextFloat(-2f, -4f) ,0), Quaternion.identity);
        newPlatform.transform.parent = gameObject.transform;
        score += 1;
        PlayerPrefs.SetInt("CurrentRunScore",score);
    }

    static float NextFloat(float min, float max){
        System.Random random = new System.Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }
}
