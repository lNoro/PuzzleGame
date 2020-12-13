using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaking : MonoBehaviour
{
    public float ReadTime = 4f;

    public float Interval = 8f;

    private float m_NextText = 0f;
    private float m_CloseText = 0f;

    public GameObject[] Bubbles;
    public GameObject[] BubblesRoom2;


    private int m_Index = 0;

    private GameObject m_CurrentText;

    private Quaternion m_Rotation;

    private bool m_EnteredRoom2 = false;


    private void Start()
    {
        m_Rotation = Bubbles[m_Index].transform.rotation;
        m_NextText = Time.time + 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_CurrentText != null && Time.time >= m_CloseText)
        {
            m_CurrentText.GetComponent<SpriteRenderer>().enabled = false;
            m_CurrentText = null;
        }
        
        if (m_Index < Bubbles.Length)
        {
            if (Time.time >= m_NextText)
            {
                m_CurrentText = Bubbles[m_Index++];
                m_CurrentText.GetComponent<SpriteRenderer>().enabled = true;
                m_CloseText = Time.time + ReadTime;
                m_NextText = Time.time + Interval;
            }
        }
    }

    private void LateUpdate()
    {
        if (m_CurrentText != null)
        {
            m_CurrentText.transform.rotation = m_Rotation;
        }
    }

    public void DialogsRoom2()
    {
        if (!m_EnteredRoom2)
        {
            Bubbles = BubblesRoom2;
            m_Index = 0;
            m_CurrentText = null;
            m_EnteredRoom2 = true;
            m_NextText = Time.time + 2f;
            m_CloseText = 0f;
        }
    }

    public bool EnteredRoom2()
    {
        return m_EnteredRoom2;
    }
}
