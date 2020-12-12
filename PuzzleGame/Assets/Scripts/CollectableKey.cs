using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableKey : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject inventorySoundController = GameObject.Find("Inventory_Sound_Controller");

        if(other.GetComponentInParent<Player>() != null)
        {
            Player player = other.GetComponentInParent<Player>();
            if(gameObject.CompareTag("Key"))
            {
                player.Key = true;
                inventorySoundController.GetComponent<InventorySoundController>().playInventorySound();
            }
            else if(gameObject.CompareTag("Weight"))
            {
                player.Weight = true;
                inventorySoundController.GetComponent<InventorySoundController>().playInventorySound();
            }
            Destroy(gameObject);
        }
    }
}
