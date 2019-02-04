using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCamera : MonoBehaviour
{
    public GameObject sun;
    private float distance;
    public float rotationSkybox = 0.5f;

    void Start()
    {
        distance = transform.position.y - sun.transform.position.y;
        StartCoroutine(MoveSkybox());
    }


    IEnumerator MoveSkybox()
    {
        while (true)
        {
            GetComponent<Skybox>().material.SetFloat("_Rotation", 140+Time.time * rotationSkybox);
            yield return null;
        }
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
