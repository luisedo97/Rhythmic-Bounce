using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private void Start()
    {
                
    }

    public bool Up(float height, float upCubeSpeed) {

        //transform.position += Vector3.up * upCubeSpeed * Time.deltaTime;
        Vector3 step = new Vector3(transform.position.x, height, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, step, Time.deltaTime * upCubeSpeed);

        if (transform.position.y == height)
        {
            //transform.position = new Vector3(transform.position.x, height, transform.position.z);
            
            return true;
        }
        else
        {
            return false;
        }
        //Debug.Log("Movement Cube:" + (transform.position.y - Movement));
        
    }

    public float GetPositionY() {
        return transform.position.y;
    }

}
