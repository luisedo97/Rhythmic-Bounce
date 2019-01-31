using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject sun;
    public Cube[] cubes;
    [Range(0, 100)]
    public float speedRotate = 10;
    [Range(1, 50)]
    public float upCubeSpeed = 10f;
    private float height;

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
        transform.RotateAround(sun.transform.position, Vector3.up, speedRotate*Time.deltaTime);
        transform.position = new Vector3(transform.position.x, sun.transform.position.y, transform.position.z);
    }
}
