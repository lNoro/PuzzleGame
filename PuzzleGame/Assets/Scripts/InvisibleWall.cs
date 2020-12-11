using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWall : MonoBehaviour
{
    public float FadeTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Color current = GetComponent<Renderer>().material.color;
        Color visible = current;
        visible.a = 255f;
        GetComponent<Renderer>().material.color = Color.Lerp(current, visible, Time.deltaTime * FadeTime);
    }

    private void OnCollisionExit(Collision other)
    {
        Color current = GetComponent<Renderer>().material.color;
        Color visible = current;
        visible.a = 0f;
        GetComponent<Renderer>().material.color = Color.Lerp(current, visible, Time.deltaTime * FadeTime);
    }
}
