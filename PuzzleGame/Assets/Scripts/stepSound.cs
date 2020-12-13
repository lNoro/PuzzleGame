using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepSound : MonoBehaviour
{
    public AudioSource steps;

    bool startPlay = false;
    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) {
            Debug.Log(Input.GetAxis("Horizontal") + " " +Input.GetAxis("Vertical"));
            Debug.Log("Hit");
            steps.GetComponent<AudioSource>();
            if(startPlay == true) {
                steps.Play();
                startPlay = false;
            }
        } else{
            steps.Pause();
            startPlay = true;
        }
    }
}
