using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBallExploding : MonoBehaviour
{
    [SerializeField] PlayerHealthScript playerHealth;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(10);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("EnemyHit");
            EnemyAI enemy = collision.gameObject.GetComponent<EnemyAI>();
            if (enemy != null)
            {
                enemy.EnemyTakeDamage(25);
            }
            Destroy(gameObject);
        }else if(collision.gameObject.tag == "Ground")
        {
            Debug.Log("GroundHit");
        }
        else Destroy(gameObject);
        
        
    }
}
