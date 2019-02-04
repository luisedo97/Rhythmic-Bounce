using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    private bool pause = false;
    public AudioSource audioComponent;
    public Sprite onSprite;
    public Sprite offSprite;
    public void MusicPause()
    {
        pause = !pause;
        if (pause)
        {
            audioComponent.Pause();
            GetComponent<Image>().sprite = offSprite;
        }
        else
        {
            audioComponent.UnPause();
            GetComponent<Image>().sprite = onSprite;
        }
    }
}
