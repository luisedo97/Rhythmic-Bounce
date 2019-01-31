using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float thrust = 10f;
    public bool isGrounded = false;

    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            Debug.Log("Space");
            rb.AddForce(transform.up*thrust, ForceMode.Impulse);
        }       
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
