using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue
{
    [TextArea]
    public string txt;
}

public class IntroManager : MonoBehaviour
{
    public Image talkPanel;
    public Text text;
    public RawImage fadeImage;

    private bool isTalk = false;
    private int count = 0;
    public float fadeSpeed = 0.4f;

    public enum FadeDirection
    {
        In, // Alpha = 1
        Out // Alpha = 0
    }

    [SerializeField] private Dialogue[] dialogue;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ShowDialogue();
        }
    }

    public void ShowDialogue()
    {
        talkPanel.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
    }

    // Scene Fade-In
    private void OnEnable()
    {
        StartCoroutine(Fade(FadeDirection.Out));
    }

    private IEnumerator Fade(FadeDirection fadeDirection)
    {
        float alpha = (fadeDirection == FadeDirection.Out) ? 1 : 0;
        float fadeEndValue = (fadeDirection == FadeDirection.Out) ? 0 : 1;
        if (fadeDirection == FadeDirection.Out)
        {
            while (alpha >= fadeEndValue)
            {
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }
            fadeImage.enabled = false;
        }
        else
        {
            fadeImage.enabled = true;
            while (alpha <= fadeEndValue)
            {
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }
        }
    }

    private void SetColorImage(ref float alpha, FadeDirection fadeDirection)
    {
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alpha);
        alpha += Time.deltaTime * (1.0f / fadeSpeed) * ((fadeDirection == FadeDirection.Out) ? -1 : 1);
    }
}
