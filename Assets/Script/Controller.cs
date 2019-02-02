using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Controller : MonoBehaviour
{
    public float speedGlobal = 1f;
    public TextMeshProUGUI score;

    private void Awake()
    {
        score = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        StartCoroutine(speedIncrease());
    }

    private void Update()
    {
        //multipliquer = GameObject.Find("Scrollbar").GetComponent<Scrollbar>().value;
        //Debug.Log("Multipliquer:"+multipliquer);
    }

    IEnumerator speedIncrease()
    {
        while (true)
        {
            speedGlobal += 0.01f;
            yield return new WaitForSeconds(1f);
        }
    }

    public void jump(int countBouncing)
    {
        score.SetText(""+countBouncing);
    }

}
