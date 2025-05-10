using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBallExploding : MonoBehaviour
{
    [SerializeField] PlayerHealthScript playerHealth;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("PlayerTouched");

            // Try to get PlayerHealthScript from the player object
            PlayerHealthScript health = collision.gameObject.GetComponent<PlayerHealthScript>();
            if (health != null)
            {
                health.TakeDamage(10);
            }

            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("EnemyHit");
            EnemyAI enemy = collision.gameObject.GetComponent<EnemyAI>();
            if (enemy != null)
            {
                enemy.EnemyTakeDamage(25);
            }

            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("GroundHit");
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
