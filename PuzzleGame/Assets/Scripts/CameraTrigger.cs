using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public GameObject Camera;
    

    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.CompareTag("Room1"))
            Camera.GetComponent<CameraControl>().GoToStartRoom();
        else if(gameObject.CompareTag("Room2"))
            Camera.GetComponent<CameraControl>().GoToLightRoom();
    }
}
