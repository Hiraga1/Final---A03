using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingNPC : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;
    public Transform waypoints; //waypoints list
    public float speed = 2; //Speed of the cube
    
    int index;

    private void Update()
    {
        if (agent.remainingDistance <= 0.2f)
        {
            index++;

            if (index >= waypoints.childCount)
            {
                index = 0;
            }

            agent.SetDestination(waypoints.GetChild(index).position);

        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC End"))
        {
            Destroy(gameObject); // Destroys the NPC
            Debug.Log("Touched");
        }
    }
}
