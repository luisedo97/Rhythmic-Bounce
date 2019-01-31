using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    public void up(float height, float upCubeSpeed) {
        StartCoroutine(movement(height,upCubeSpeed));
    }

    IEnumerator movement(float height, float upCubeSpeed) {
        float Movement = transform.position.y;
        while (transform.position.y <= height)
        {
            
            transform.Translate(Vector3.up * upCubeSpeed * Time.deltaTime);
            yield return null;
        }
        //Debug.Log("Movement Cube:" + (transform.position.y - Movement));
        transform.position = new Vector3(transform.position.x, height, transform.position.z);
        
    }

    public float getPositionY() {
        return transform.position.y;
    }

}
