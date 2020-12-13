using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayDown : MonoBehaviour
{
    public GameObject lamp;
    public Image buttonE;

    public GameObject player;

    AudioSource victory;

    bool playSoundOnce = true;

    private void Update() {
    if(lamp.GetComponent<lampPuzzle>().returnGameState() && playSoundOnce) {
        playSoundOnce = false;
        victory = GetComponent<AudioSource>();
        victory.Play();
    }

        if(Vector3.Distance(transform.position, player.transform.position) < 3 && lamp.GetComponent<lampPuzzle>().returnGameState()) {
            buttonE.enabled = true;
            if(Input.GetKeyDown(KeyCode.E)) {
                player.gameObject.GetComponent<Rigidbody>().useGravity = false;
                player.gameObject.GetComponent<Rigidbody>().detectCollisions = false;
                player.GetComponent<PlayerController>().enabled = false;
                player.GetComponent<Animator>().enabled = false;
                player.gameObject.transform.position = new Vector3(1.6f, 2.4f, -3f);
                player.gameObject.transform.eulerAngles = new Vector3(-90, 0, 0); 
                buttonE.enabled = false;
            }
        } else{
            buttonE.enabled = false;
        }

    }
}
