using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using static Hertzole.GoldPlayer.Example.MovingPlatform;


public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public GameObject waterBalls;

    public int wetLevelMax = 100;
    public int currentWetLevel = 0;

    public WetBarScript wetBar;
    public Slider wetBarSlider;

    public PlayerHealthScript playerHealth;

    public Animator animator;

    //Patrolling with waypoints
    public Transform waypoints; //waypoints list
    public float speed = 2; //Speed of the cube
    int index;

   

    //Attacking

    public float throwingCdEnemy;
    bool alreadyThrew;
    public Transform throwingPoint;

    //States
    public float sightRange, throwingRange;
    public bool playerInSightRange, playerInThrowingRange;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("PlayerObj").transform;
    }

    private void Start()
    {
        wetBar.SetWetValue(currentWetLevel);
    }

    private void Update()
    {
        
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInThrowingRange = Physics.CheckSphere(transform.position, throwingRange, whatIsPlayer);

        if (!playerInSightRange && !playerInThrowingRange) //Patrolling

        {
            
            if(agent.remainingDistance <= 0.2f)
            {
                index++;
                
                    if(index >= waypoints.childCount)
                    {
                        index = 0;
                    }

                    agent.SetDestination(waypoints.GetChild(index).position);
                
            }
            animator.SetTrigger("Walking");
        }
        if (playerInSightRange && !playerInThrowingRange) ChasePlayer();
        if (playerInSightRange && playerInThrowingRange) AttackPlayer();
        wetBarSlider.value = currentWetLevel;
        if (currentWetLevel == wetLevelMax)
        {
            playerHealth.enemiesSoaked++;
            Destroy(gameObject);
        }
    }



    

    private void ChasePlayer()
    {
       
        agent.SetDestination(player.position);
        animator.SetTrigger("Walking");
    }

    private void AttackPlayer()
    {
        // Enemy stops moving
        agent.SetDestination(transform.position);

        // Face the player (only rotate on Y axis)
        Vector3 lookPos = player.position - transform.position;
        lookPos.y = 0;
        transform.rotation = Quaternion.LookRotation(lookPos);

        if (!alreadyThrew)
        {
            animator.SetTrigger("Throw"); // Start the animation
            alreadyThrew = true;

            // Optionally delay the actual projectile throw slightly to match animation
            Invoke(nameof(PerformThrow), 2.1f); // 0.5s delay can match animation timing
            Invoke(nameof(ResetThrow), throwingCdEnemy);
        }
    }
    private void PerformThrow()
    {
        Rigidbody rb = Instantiate(waterBalls, throwingPoint.position, throwingPoint.rotation).GetComponent<Rigidbody>();
        rb.AddForce(throwingPoint.forward * 32f, ForceMode.Impulse);
    }

    private void ResetThrow()
    {
        alreadyThrew = false;
    }

    public void EnemyTakeDamage(int enemyWetLevel)
    {
        currentWetLevel += enemyWetLevel;

       
    }
    private void OnDrawGizmos()
    {
        // Draw forward direction (blue)
        Gizmos.color = Color.blue;
        Vector3 forward = transform.forward * 10f;
        Gizmos.DrawLine(transform.position + Vector3.up * 1.5f, transform.position + Vector3.up * 1.5f + forward);

        // Draw throwing point direction if set
        if (throwingPoint != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(throwingPoint.position, throwingPoint.position + throwingPoint.forward * 2f);
        }
    }

}

