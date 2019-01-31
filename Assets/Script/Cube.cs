using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{


    public bool up(float height, float upCubeSpeed) {
        
        transform.position += Vector3.up * upCubeSpeed * Time.deltaTime;

        if (transform.position.y >= height)
        {
            transform.position = new Vector3(transform.position.x, height, transform.position.z);
            return true;
        }
        else
        {
            return false;
        }
        //Debug.Log("Movement Cube:" + (transform.position.y - Movement));
        
    }

    

    public float getPositionY() {
        return transform.position.y;
    }

}
