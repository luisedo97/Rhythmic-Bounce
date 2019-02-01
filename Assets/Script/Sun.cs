using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float speed = 1f;
    private float yAux;

    void Update()
    {
        sunMovement();
    }

    private void Start()
    {
        StartCoroutine("Counter");
        yAux = transform.position.y + speed;
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

    void sunMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, Vector3.up*yAux, Time.deltaTime * speed);
        
        //transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (transform.position.y == yAux) {
            //transform.position = Vector3.up * yAux;
            yAux += speed;
        }
    }
}
