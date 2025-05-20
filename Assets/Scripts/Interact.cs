using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable //interface class makes sure the object activates on click
{
    public void OnInteract(); //Activates the moving
}
public class Interact : MonoBehaviour
{
    public Transform InteractorSource; //Source of Interaction  
    public float InteractRange; //Interact Range
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            Ray ray = new Ray(InteractorSource.position, InteractorSource.forward); //Cast a ray and foward
            if (Physics.Raycast(ray, out RaycastHit hitInfo, InteractRange)) //If the ray hit anything, return a value
            {
                if(hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj)) //if the ray hits an interactable object, trigger the interact event
                {
                    interactObj.OnInteract();
                }
            }
        }
    }

}
