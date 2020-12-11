using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private bool m_MoveCam = false;
    private Vector3 m_AimPosition;
    private void Update()
    {
        if (transform.position == m_AimPosition)
            m_MoveCam = false;
        
        if (m_MoveCam)
        {
            transform.position = Vector3.Lerp(transform.position, m_AimPosition, Time.deltaTime * 4f);
        }
    }

    public void GoToLightRoom()
    {
        m_AimPosition = new Vector3(transform.position.x, transform.position.y, 14);
        m_MoveCam = true;
    }
}
