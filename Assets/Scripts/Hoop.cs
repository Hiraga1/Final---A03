using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    [SerializeField]
    private BasketBall basketBallScript;
    public GameObject lebron;
    public GameObject dialogTriggerObject;
    public GameObject playerObject;
    public GameObject particles;
    private void OnTriggerEnter(Collider other)
    {    
            lebron.SetActive(true);
            dialogTriggerObject.transform.position = playerObject.transform.position;
            particles.SetActive(true);
        Invoke(nameof(StopLebron), 81f);
    }
    void StopLebron()
    {
        lebron.SetActive(false);
        Destroy(dialogTriggerObject);
    }
}
