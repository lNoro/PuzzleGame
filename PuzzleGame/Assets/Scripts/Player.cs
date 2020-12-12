using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject WeightPrefab;

    public Image buttonQ;
    
    AudioSource weight_drop_m;
    private bool m_Key;
    private bool m_Weight;

    // Start is called before the first frame update
    void Start()
    {
        buttonQ.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {   
        if(m_Weight == true) 
            buttonQ.enabled = true;
        else
            buttonQ.enabled = false;

        if (Input.GetKeyDown(KeyCode.Q) && m_Weight == true)
        {
            PlaceWeightInFront();
            weight_drop_m = GetComponent<AudioSource>();
            weight_drop_m.Play();
        }
    }

    public bool Key
    {
        get => m_Key;
        set => m_Key = value;
    }
    
    public bool Weight
    {
        get => m_Weight;
        set => m_Weight = value;
    }

    private void PlaceWeightInFront()
    {
        if (m_Weight)
        {
            WeightPrefab.transform.rotation = transform.rotation;
            WeightPrefab.transform.position = transform.position;
            WeightPrefab.transform.Translate(Vector3.forward, Space.Self);
            Instantiate(WeightPrefab, WeightPrefab.transform.position, WeightPrefab.transform.rotation);
            m_Weight = false;
        }
    }

    private Vector3 GetFrontVector()
    {
        float rot = transform.rotation.y;
        Vector3 vector = Vector3.zero;
        switch (rot)
        {
            case 0:
                vector = Vector3.forward;
                break;
            
            case -180:
                vector =  Vector3.back;
                break;
            
            case 90:
                vector =  Vector3.right;
                break;
            
            case -90:
                vector =  Vector3.left;
                break;
        }

        return vector;
    }
}
