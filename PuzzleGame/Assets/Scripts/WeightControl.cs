using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightControl : MonoBehaviour
{
    public GameObject InvisibleWallToDestroy;
    private Vector3 m_PositionOfWall;
    private Vector3 m_PositionWhileOnTrigger;
    private int m_Count = 0;

    private void Start()
    {
        m_PositionOfWall = InvisibleWallToDestroy.transform.position;
        m_PositionWhileOnTrigger = new Vector3(-6, m_PositionOfWall.y, m_PositionOfWall.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        InvisibleWallToDestroy.transform.position = m_PositionWhileOnTrigger;
        m_Count++;
    }

    private void OnTriggerExit(Collider other)
    {
        if(--m_Count == 0)
            InvisibleWallToDestroy.transform.position = m_PositionOfWall;
    }
}
