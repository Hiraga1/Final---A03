using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform throwingPoint;
    public GameObject waterBall;

    [Header("Settings")]
    public int totalWaterBalls;
    public float throwCD;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;

    public bool readyToThrow;

    private void Start()
    {
        readyToThrow = true;
    }

    private void Update()
    {
        
        if(Input.GetKeyDown(throwKey) && readyToThrow && totalWaterBalls > 0)
        {
            Debug.Log("throwing");

            Throw();
        }
    }
    private void Throw()
    {
        readyToThrow = false;

        GameObject projectile = Instantiate(waterBall, throwingPoint.position, cam.rotation);

        Rigidbody projectilerb = projectile.GetComponent<Rigidbody>();

        Vector3 forcetoAdd = cam.transform.forward * throwForce + transform.up * throwUpwardForce;

        projectilerb.AddForce(forcetoAdd, ForceMode.Impulse);

        totalWaterBalls--;

        Invoke(nameof(ResetThrow), throwCD);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }

}
