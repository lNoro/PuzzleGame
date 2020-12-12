using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    AudioSource ambientMusic;

    // Update is called once per frame
    
    void Start() {
        ambientMusic = GetComponent<AudioSource>();
        ambientMusic.Play();
    }
}
