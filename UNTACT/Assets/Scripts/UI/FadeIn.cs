using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    float start;
    float end;
    float time;

    public Image fadeInImage;

    void Start()
    {
        FadeInAnim();
    }

    void Update()
    {
        
    }

    void FadeInAnim()
    {
        StartCoroutine("FadeInCoroutine");
    }

    IEnumerator FadeInCoroutine()
    {
        start = 1f;
        end = 0f;
        Color color = fadeInImage.color;
        time = 0f;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a > 0f)
        {
            time += Time.deltaTime / 3f;
            color.a = Mathf.Lerp(start, end, time);
            fadeInImage.color = color;
            yield return null;
        }
    }
}
