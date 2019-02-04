using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    private Vector3 initialTransform;

    private void Start()
    {
        //Guardo mi estado actual
        initialTransform = transform.localScale;
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

    public void changeScale(string scale)
    {
        switch (scale)
        {
            case "Normal":
                transform.localScale = initialTransform;
                break;
            case "Medium":
                transform.localScale = new Vector3(initialTransform.x * 0.60f, initialTransform.y, initialTransform.z * 0.60f);
                break;
            case "Low":
                transform.localScale = new Vector3(initialTransform.x * 0.50f, initialTransform.y, initialTransform.z * 0.50f);
                break;
            case "Micro":
                transform.localScale = new Vector3(initialTransform.x * 0.40f, initialTransform.y, initialTransform.z * 0.40f);
                break;
            default:
                goto case "Normal";
        }
    }


    public float GetPositionY() {
        return transform.position.y;
    }

}
