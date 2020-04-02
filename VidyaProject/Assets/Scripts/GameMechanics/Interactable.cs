using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Interactable : MonoBehaviour
{
    public GameObject dialogBox; 
    public Signal context;
    public bool playerInRange;
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            context.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            context.Raise();
            playerInRange = false;
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false); // Turn off dialog box if leaving collision range
            }
        }
    }
}
