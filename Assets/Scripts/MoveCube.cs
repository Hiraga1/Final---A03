using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> waypoints; //waypoints list
    public float speed = 2; //Speed of the cube
    int index = 0;



    // Update is called once per frame
    private void Update()
    {
        Vector3 destination = waypoints[index].transform.position; //position of waypoints
        Vector3 newpos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime); //calculate and move towards new waypoints
        transform.position = newpos; //set new position when going through way points



        if (transform.position == destination) //Calculates if current position is in the waypoint
        {
            index++; //set destination to the next waypoint
        }
        if (index == waypoints.Count) //if reach the end of the waypoint map
        {
            index = 0; //resets waypoint to 0
            
        }
    }
}
