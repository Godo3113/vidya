using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuildingState
{
    idle,
    producing,
    destroyed
}

public class Building : MonoBehaviour
{
    [Header("State Machine")]
    public BuildingState currentState;

    [Header("Building Stats")]
    public FloatValue maxHealth;
    public float health;
    public string buildingName;

    private void Awake()
    {
        health = maxHealth.initialValue;
    }

    private void OnEnable()
    {
        //transform.position = homePosition;
        health = maxHealth.initialValue;
        currentState = BuildingState.idle;
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void Knock(float damage)
    {
        //StartCoroutine(KnockCo(myRigidbody, knockTime));
        TakeDamage(damage);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
