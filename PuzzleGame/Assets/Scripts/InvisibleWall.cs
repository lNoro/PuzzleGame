using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWall : MonoBehaviour
{
    private Material m_InvisibleMaterial;
    // Start is called before the first frame update
    void Start()
    {
        m_InvisibleMaterial = GetComponent<Material>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        m_InvisibleMaterial;
    }
}
