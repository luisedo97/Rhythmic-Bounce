using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject sun;
    public Cube[] cubes;
    [Range(0, 100)]
    public float speedRotate = 41.5f;
    [Range(1, 50)]
    public int upCubeSpeed = 16;
    private float height = 0f;
    public float speedGlobal = 1f;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        height = cubes[cubes.Length-1].transform.position.y + 0.5f;
        //StartCoroutine(upCube());
        StartCoroutine(Counter());
    }

    IEnumerator Counter()
    {
        while (true)
        {
            float counterPast = counter;
            yield return new WaitForSecondsRealtime(1f);
            //Debug.Log("Cubos movidos:" + (counter - counterPast));
        }
    }

    void upCube() {

        if (cubes[counter].up(height, upCubeSpeed))
        {
            height += 0.5f;
            Debug.Log("Diferencia:" + (sun.transform.position.y - cubes[counter].gameObject.transform.position.y));
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

    private void Update()
    {
        upCube();
        transform.position = new Vector3(transform.position.x, sun.transform.position.y, transform.position.z);
        GameObject.Find("Cubes").transform.Rotate(Vector3.up*-speedRotate*Time.deltaTime);
    }


    void FixedUpdate()
    {
        //transform.RotateAround(sun.transform.position, Vector3.up, speedRotate*Time.deltaTime);
        
    }
}
