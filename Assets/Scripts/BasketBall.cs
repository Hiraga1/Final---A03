using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketBall : MonoBehaviour, IInteractable
{
    public Transform holdPos;
    public GameObject basketBall;
    public GameObject playerObj;
    public Camera playerCamera;
    public GameObject reset;
    public float throwForce;
    private Rigidbody rb_BasketBall;
    [SerializeField]
    private bool pickedUp = false;
    public void OnInteract()
    {
        PickUpObject();
        Debug.Log("Interacted");
    }

    private void PickUpObject()
    {
        if (!pickedUp)
        {
            transform.position = holdPos.position;
            transform.parent = holdPos.transform;
            rb_BasketBall = GetComponent<Rigidbody>();
            rb_BasketBall.isKinematic = true;
            Physics.IgnoreCollision(basketBall.GetComponent<Collider>(), playerObj.GetComponent<Collider>(), true);
            pickedUp = true;
        }
    }

    void Update()
    {
        if (pickedUp)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Drop();
            }
            MoveObject();
            if (Input.GetMouseButton(0))
            {

                Throw();
                Debug.Log("throw");

            }
        }



        void Drop()
        {
            Physics.IgnoreCollision(basketBall.GetComponent<Collider>(), playerObj.GetComponent<Collider>(), false);
            rb_BasketBall.isKinematic = false;
            transform.parent = null;
            pickedUp = false;
        }
        void MoveObject()
        {
            transform.position = holdPos.transform.position;
        }
        void Throw()
        {
            Physics.IgnoreCollision(basketBall.GetComponent<Collider>(), playerObj.GetComponent<Collider>(), false);
            rb_BasketBall.isKinematic = false;
            rb_BasketBall.useGravity = true;
            Vector3 throwDirection = (playerCamera.transform.forward); // Or playerObj.transform.forward
            rb_BasketBall.AddForce(throwDirection * throwForce, ForceMode.Impulse);
            transform.parent = null;
            pickedUp = false;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == reset)
        {
            Destroy(this);
        }
    }
}
