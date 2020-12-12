using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject WallToDisappear;
    public GameObject Camera;

    private bool m_Dissolve = false;
    private Material m_MaterialToDissolve;
    private float m_Fade = 0f;

    private void Start()
    {
        m_MaterialToDissolve = WallToDisappear.GetComponent<Renderer>().material;
    }

    private void Update()
    {
        if (!m_Dissolve) return;
        
        m_Fade += Time.deltaTime;

        if (m_Fade >= 1f)
        {
            m_Fade = 1f;
            m_Dissolve = false;
            Destroy(WallToDisappear);
        }
            
        m_MaterialToDissolve.SetFloat("_Fade", m_Fade);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Camera.GetComponent<CameraControl>().GoToLightRoom();
            m_Dissolve = true;
        }
    }
}
