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
    private float height;
    public float speedGlobal = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(upCube());
        
    }

    IEnumerator upCube() {
        float height = cubes[cubes.Length-1].gameObject.transform.position.y;
        do
        {
            foreach (Cube cube in cubes)
            {
                height += 0.5f;
                cube.up(height, upCubeSpeed);
                do
                {
                    yield return null;
                } while (cube.getPositionY() != height);
                
                Debug.Log("Distancia"+(cube.gameObject.transform.position.y-sun.transform.position.y));
            }
        } while (true);
    }

    void FixedUpdate()
    {
        GameObject.Find("Cubes").transform.Rotate(new Vector3(0, -1f, 0)*speedRotate* Time.deltaTime);
        //transform.RotateAround(sun.transform.position, Vector3.up, speedRotate*Time.deltaTime);
        transform.position = new Vector3(transform.position.x, sun.transform.position.y, transform.position.z);
    }
}
