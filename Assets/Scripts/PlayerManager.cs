using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerRef;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = Instantiate(playerRef, new Vector3(0,0,0), Quaternion.identity);
        player.transform.parent = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
