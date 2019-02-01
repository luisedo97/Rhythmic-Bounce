using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject sun;
    
    
    public float speedGlobal = 1f;


    void Start()
    {

    }

    private void Update()
    {
        //upCube();
        transform.position = new Vector3(transform.position.x, sun.transform.position.y, transform.position.z);
        
    }


    void FixedUpdate()
    {
        //transform.RotateAround(sun.transform.position, Vector3.up, speedRotate*Time.deltaTime);
        
    }
}
