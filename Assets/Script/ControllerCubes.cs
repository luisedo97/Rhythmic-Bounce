using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCubes : MonoBehaviour
{

    public Cube[] cubes;
    [Range(1, 50)]
    public float upCubeSpeed = 8;
    private float height = 0f;
    private int counter = 0;
    [Range(0, 100)]
    private float errorTimeSg;
    private int counterLap = 0;
    private Controller controller;


    void Awake()
    {
        controller = GameObject.Find("Controller").GetComponent<Controller>();
    }

    private void Start()
    {
        errorTimeSg = 0f;
        height = cubes[cubes.Length - 1].transform.position.y + 0.5f;
    }

    void Update()
    {
        UpCube();
        RotateCube();
        //transform.Rotate(Vector3.up,-(360 / 16.07f) * controller.speedGlobal * Time.deltaTime);
        //transform.rotation = Quaternion.RotateTowards(transform.rotatio, Time.deltaTime * upCubeSpeed);
        //Debug.Log(-(360 / (16f * controller.speedGlobal)));
    }

    void RotateCube()
    {
        transform.Rotate(Vector3.up, -(360 / (16.07f)) * controller.speedGlobal * Time.deltaTime);
    }


    void UpCube()
    {
        
        if (cubes[counter].Up(height, upCubeSpeed * controller.speedGlobal))
        {
            height += 0.5f;
            RandomChangeCube(cubes[counter]);
            if (counter + 1 == cubes.Length)
            {
                counter = 0;
                counterLap++;
                errorTimeSg = (Time.time - (int)(Time.time))/counterLap;
                Debug.Log("Error Time sg:" + errorTimeSg);
            }
            else
            {
                //Debug.Log("Time lap" + Time.time);
                counter++;
            }
        }
    }

    void RandomChangeCube(Cube cube)
    {
        int random = Random.Range(0, 12);

        switch (random) {
            case 0:
                cube.transform.localScale = Vector3.one / 3f;
                break;
            case 1:
                cube.transform.localScale = Vector3.one / 2f;
                break;
            case 2:
                cube.transform.localScale = Vector3.one / 2f;
                break;
            case 3:
                cube.transform.localScale = Vector3.one / 1.5f;
                break;
            case 4:
                cube.transform.localScale = Vector3.one / 1.5f;
                break;
            case 5:
                cube.transform.localScale = Vector3.one / 1.5f;
                break;
            default:
                cube.transform.localScale = Vector3.one;
                break;
        }
    }
}
