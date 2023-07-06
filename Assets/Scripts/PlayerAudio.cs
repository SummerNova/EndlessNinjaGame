using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PlayerAudio : MonoBehaviour
{
    Random rng = new Random();
    public List<AudioClip> step = new List<AudioClip>();
    public List<AudioClip> jump = new List<AudioClip>();
    public AudioClip dash;
    public AudioSource source;
    public AudioSource Ability;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Step(){
        source.clip = step[rng.Next(0,9)];
        source.Play();
    }

    public void Jump(){
        Ability.clip = jump[0];
        Ability.Play();
    }

    public void Dash(){
        Ability.clip = dash;
        Ability.Play();
    }
}
