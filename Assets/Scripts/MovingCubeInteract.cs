using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

    


public class MovingCubeInteract : MonoBehaviour, IInteractable
{
    public void OnInteract()
    {
        this.GetComponent<MoveCubeScript>().enabled = true; //enable the script
    }
    
        
}
