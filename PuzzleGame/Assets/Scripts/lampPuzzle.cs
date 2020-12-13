using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;


public class lampPuzzle : MonoBehaviour
{
    public GameObject player;
    private float viewDist = 3;

    [SerializeField]
    private KeyCode toggleLampVisibilty;

    [SerializeField]
    private GameObject pointLight;

    [SerializeField]
    bool isPuzzleLamp = false;

    [SerializeField]
    static int puzzleLampsTurnedOn = 0;
    [SerializeField]
    static int normalLampsTurnedOn = 0;
    private bool lampOn = true;

    private bool puzzleSolved = false;
    
    public Image LampeAus;
    public Image LampeAn;

    AudioSource lightSwitch;

    void Start()
    {
        LampeAus.enabled = false;
        LampeAn.enabled = false;
    }
    void Update() {
        //Falls alle normalen Lampen aus sind und alle Puzzle Lampen an, lößt man das Puzzle (Dann gehen alle Lampen im Raum an)
        if(normalLampsTurnedOn == 0 && puzzleLampsTurnedOn == 4){
            pointLight.SetActive(true);
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            Debug.Log("Solved");
            puzzleSolved = true;
            player.GetComponent<Player>().PuzzleSolved();
        }
        Debug.Log(puzzleSolved);
    }

    private void OnMouseOver() {
        //Schaut ob Distanz zwischen Lampe und Spiele unter einem bestimmten Wert liegt, dann kann man mit der lampe interagieren
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if(puzzleSolved == false) {
            Debug.Log("Hit");
            
            //Lampe wird gehighlighted
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
            LampeAus.enabled = true;
            LampeAn.enabled = true;

            if(lampOn == true){
                LampeAus.enabled = true;
                LampeAn.enabled = false;
            } else {
                LampeAn.enabled = true;
                LampeAus.enabled = false;
            }


            if(Input.GetKeyDown(toggleLampVisibilty)) {
                lightSwitch = GetComponent<AudioSource>();
                lightSwitch.Play();

                //Lampe wird aktiviert und abhängig von Lampentyp wird Lampenanzahl inkrementiert 
                if(lampOn == true){

                    pointLight.SetActive(true);
                    lampOn = false;
                    if(isPuzzleLamp) puzzleLampsTurnedOn++;
                    else normalLampsTurnedOn++;
                //Lampe wird deaktiviert und abhängig von Lampentyp wird Lampenanzahl dekrementiert 
                } else {
                    pointLight.SetActive(false);
                    lampOn = true;
                    if(isPuzzleLamp) puzzleLampsTurnedOn--;
                    else normalLampsTurnedOn--;
                }

            }
        }
    }

    private void OnMouseExit() 
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white;
        LampeAus.enabled = false;
        LampeAn.enabled = false;
    }

    public bool returnGameState() {
        return puzzleSolved;
    }
}
