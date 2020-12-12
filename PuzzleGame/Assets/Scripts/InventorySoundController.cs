using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySoundController : MonoBehaviour
{
    AudioSource inventory_sound;

    public void playInventorySound() {
       inventory_sound = GetComponent<AudioSource>();
       inventory_sound.Play();
    }
}
