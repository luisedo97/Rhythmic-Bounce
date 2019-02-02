using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Controller : MonoBehaviour
{
    public float speedGlobal;
    public float multipliquer = 0f;
    public TextMeshProUGUI score;

    private void Awake()
    {
        score = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();       
    }

    private void Update()
    {
        multipliquer = GameObject.Find("Scrollbar").GetComponent<Scrollbar>().value;
        Debug.Log("Multipliquer:"+multipliquer);
        speedGlobal = 1 + multipliquer;
    }

    public void jump(int countBouncing)
    {
        score.SetText(""+countBouncing);
    }

}
