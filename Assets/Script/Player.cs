using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float thrust = 10f;
    public bool isGrounded = false;
    public int countBouncing = 0;
    private Controller controller;

    private void Start()
    {
        controller = GameObject.Find("Controller").GetComponent<Controller>();
    }

    private void Update()
    {
        Jump();
    }

    public void Jump() {
        if (isGrounded)
        {
            countBouncing++;
            controller.jump(countBouncing);
            Rigidbody rb = GetComponent<Rigidbody>();
            Debug.Log("Space");
            rb.AddForce(transform.up * thrust, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

}
