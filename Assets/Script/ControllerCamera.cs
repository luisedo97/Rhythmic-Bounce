using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCamera : MonoBehaviour
{
    public GameObject sun;
    private float distance;

    void Start()
    {
        distance = transform.position.y - sun.transform.position.y;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, sun.transform.position.y + distance, transform.position.z);
    }


    void FixedUpdate()
    {
        //transform.RotateAround(sun.transform.position, Vector3.up, speedRotate*Time.deltaTime);

    }
}
