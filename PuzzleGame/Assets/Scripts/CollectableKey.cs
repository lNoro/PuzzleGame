using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableKey : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponentInParent<Player>() != null)
        {
            Player player = other.GetComponentInParent<Player>();
            if(gameObject.CompareTag("Key"))
            {
                player.Key = true;
            }
            else if(gameObject.CompareTag("Weight"))
            {
                player.Weight = true;
            }
            Destroy(gameObject);
        }
    }
}
