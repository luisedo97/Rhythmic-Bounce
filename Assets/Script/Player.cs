using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    public float thrust = 10f;
    public bool isGrounded = false;
    public int countBouncing = 0;
    private Controller controller;
    public Joystick joystick;

    private void Start()
    {
        controller = GameObject.Find("Controller").GetComponent<Controller>();
    }

    private void Update()
    {
        Jump();
        transform.position = new Vector3(joystick.Horizontal, transform.position.y, transform.position.z);
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
