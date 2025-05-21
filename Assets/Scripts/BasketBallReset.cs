using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBallReset : MonoBehaviour
{
    [SerializeField]
    private Transform resetPos;
    [SerializeField]
    private GameObject basketBall;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == basketBall)
        {
            Instantiate(basketBall, resetPos);
        }
    }
}
