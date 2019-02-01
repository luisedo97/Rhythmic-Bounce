using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCubes : MonoBehaviour
{

    public Cube[] cubes;
    [Range(1, 50)]
    public float upCubeSpeed = 16;
    private float height = 0f;
    private int counter = 0;
    [Range(0, 100)]
    public float speedRotate = 41.5f;

    void Awake()
    {
        height = cubes[cubes.Length - 1].transform.position.y + 0.5f;
    }

    void Update()
    {
        upCube();
        transform.Rotate(Vector3.up * -speedRotate * Time.deltaTime);
    }


    void upCube()
    {
        if (cubes[counter].up(height, upCubeSpeed))
        {
            height += 0.5f;
            //Debug.Log("Diferencia:" + (sun.transform.position.y - cubes[counter].gameObject.transform.position.y));
            if (counter + 1 == cubes.Length)
            {
                counter = 0;
            }
            else
            {
                counter++;
            }
        }
    }

    //Debuger
    IEnumerator Debuger()
    {
        while (true)
        {
            float counterPast = counter;
            yield return new WaitForSecondsRealtime(1f);
            //Debug.Log("Cubos movidos:" + (counter - counterPast));
        }
    }
}
