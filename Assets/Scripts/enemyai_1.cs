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

    //Patrolling with waypoints
    public List<GameObject> waypoints; //waypoints list
    public float speed = 2; //Speed of the cube
    int index = 0;

   

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
            Vector3 destination = waypoints[index].transform.position;
            Vector3 newpos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime); //calculate and move towards new waypoints
            transform.position = newpos; //set new position when going through way points

            if (transform.position == destination)
            {
                index++; /*go to the next waypoint*/

            }
            if (index == waypoints.Count) //if reach the end of the waypoint map
            {
                index = 0; //resets waypoint to 0
                waypoints.Reverse(); //reverse the order of the waypoint

            }
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
    }

    private void AttackPlayer()
    {
        //Enemy stays still when shooting 
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyThrew)
        {
            Rigidbody rb = Instantiate(waterBalls, throwingPoint.transform.position, Quaternion.identity).GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 5f, ForceMode.Impulse);
            alreadyThrew = true;
            Invoke(nameof(ResetThrow), throwingCdEnemy);
        }
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

