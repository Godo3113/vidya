using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : Powerup
{
    public FloatValue playerHealth;
    //public FloatValue heartContainers;
    public float amountToIncrease;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            if((playerHealth.RuntimeValue += amountToIncrease) >= playerHealth.initialValue)
            {
                playerHealth.RuntimeValue = playerHealth.initialValue;
            }
            else
            {
                playerHealth.RuntimeValue += amountToIncrease;
            }
            //if(playerHealth.initialValue > heartContainers.RuntimeValue * 2f)
            //{
            //    playerHealth.initialValue = heartContainers.RuntimeValue * 2f;
            //}
            powerupSignal.Raise(); // Update IA with new health
            Destroy(this.gameObject);
        }
    }
}
