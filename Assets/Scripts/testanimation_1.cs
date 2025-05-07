using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimation : MonoBehaviour
{
    public Animator transition;
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            transition.SetTrigger("Waking UP");
        }
        if(Input.GetKeyDown(KeyCode.N))
        {
            transition.SetTrigger("Sleeping");
        }
    }
}
