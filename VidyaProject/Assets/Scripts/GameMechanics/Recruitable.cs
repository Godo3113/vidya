using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recruitable : Interactable
{
    public GameObject recruitedUnit;
    public Inventory playerInventory;
    public Signal updateCoins;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (Input.GetButtonDown("interact") && playerInRange)
        {
            if(playerInventory.coins >= 1)
            {
                playerInventory.coins -= 1;
                updateCoins.Raise();
                GameObject current = Instantiate(recruitedUnit, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }

            // Dialoge box if needed
            /*
            
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }*/
        }
    }
}
