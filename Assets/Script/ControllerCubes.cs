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
        int random = Random.Range(0, 10);
        switch (random) {
                //Caso de que se vuelva mediano
            case 0:
                cube.changeScale("Medium");
                break;
            case 1:
                goto case 0;
            case 2:
                goto case 1;
                //Caso de que se vuelva peque;o
            case 3:
                cube.changeScale("Low");
                break;
            case 4:
                goto case 3;
                //Caso de que se vuelva micro
            case 5:
                cube.changeScale("Micro");
                break;
                //Caso de que se vuelva normal
            default:
                cube.changeScale("Normal");
                break;
        }
    }
}
