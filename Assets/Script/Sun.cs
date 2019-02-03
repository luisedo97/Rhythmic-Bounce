using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float speed = 1f;
    private float yAux;
    private Controller controller;

    private void Start()
    {
        StartCoroutine("Counter");
        yAux = transform.position.y + speed;
        controller = GameObject.Find("Controller").GetComponent<Controller>();
    }

    void Update()
    {
        SunMovement();
    }

    IEnumerator Counter()
    {
        while (true)
        {
            float yActual = transform.position.y;
            yield return new WaitForSeconds(1f);
            //Debug.Log("Desplazamiento:" + (transform.position.y - yActual));
        }
    }

    void SunMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, Vector3.up*yAux, Time.deltaTime * speed * controller.speedGlobal);
        
        //transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (transform.position.y == yAux) {
            //transform.position = Vector3.up * yAux;
            yAux += speed;
        }
    }
}
