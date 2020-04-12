using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust; // Force of the player knockback
    public float knockTime;
    public float damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("breakable") && this.gameObject.CompareTag("Player"))
        {
            other.GetComponent<pot>().Smash();
        }

        if (other.gameObject.CompareTag("building") && this.gameObject.CompareTag("enemy"))
        {
            other.GetComponent<Building>().Knock(damage);
        }

        if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("ally"))
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if(hit !=null)
            {
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);

                if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("ally") && other.isTrigger)
                {
                    hit.GetComponent<EnemyMaster>().currentState = EnemyState.stagger;
                    other.GetComponent<EnemyMaster>().Knock(hit, knockTime, damage);
                }
                if (other.gameObject.CompareTag("Player"))
                {
                    if(other.GetComponent<PlayerMovement>().currentState != PlayerState.stagger)
                    {
                        hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                        other.GetComponent<PlayerMovement>().Knock(knockTime, damage);
                    }
                }
            }
        }
    }

    private IEnumerator KnockCo(Rigidbody2D enemy)
    {
         if(enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            enemy.GetComponent<EnemyMaster>().currentState = EnemyState.idle;
        }
    }
}
