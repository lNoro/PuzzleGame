using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public GameObject PlayerModel;
    private float m_TowardsY = 0f;

    private Animator m_Animator;
        // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovement();
    }

    private void CheckMovement()
    {
        float horMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");
        m_Animator.SetFloat("Movement", Mathf.Abs(horMovement) + Mathf.Abs(verMovement));

        transform.Translate(Vector3.forward * (horMovement * Speed * Time.deltaTime), Space.World);
        transform.Translate(Vector3.left * (verMovement * Speed * Time.deltaTime), Space.World);
        
        if (horMovement > 0f)
        {
            m_TowardsY = 0f;
        }
        else if (horMovement < 0f)
        {
            m_TowardsY = -180f;
        }

        if (verMovement > 0f)
        {
            m_TowardsY = -90f;
        }
        else if (verMovement < 0f)
        {
            m_TowardsY = 90f;
        }

        PlayerModel.transform.rotation = Quaternion.Lerp(PlayerModel.transform.rotation, Quaternion.Euler(0f, m_TowardsY, 0f), Time.deltaTime * 10f);
    }
}
