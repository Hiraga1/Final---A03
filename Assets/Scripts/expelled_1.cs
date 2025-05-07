using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expelled : MonoBehaviour
{
    public bool expelled;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Water Ball")
        {
            expelled = true;
            //Teleplayer to island 
        }
    }
}
