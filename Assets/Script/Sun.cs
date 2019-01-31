using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Start()
    {
        StartCoroutine("Counter");
        StartCoroutine("sunMovement");
    }

    IEnumerator Counter()
    {
        while (true)
        {
            float yActual = transform.position.y;
            yield return new WaitForSeconds(1f);
            //Debug.Log("Desplazamiento:"+(transform.position.y-yActual));
        }
    }

    IEnumerator sunMovement() {
        while (true)
        {
            float height = transform.position.y+1f;
            float Movement = transform.position.y;
            do
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
                yield return null;
            } while (transform.position.y <= height);
            //Debug.Log("Movement Sun:" + (transform.position.y - Movement));

            transform.position = new Vector3(transform.position.x, height, transform.position.z);
        }
    }
}
