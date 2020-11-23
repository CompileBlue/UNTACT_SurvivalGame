using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    [TextArea]
    public string text;
}

public class IntroManager : MonoBehaviour
{
    public Image talkPanel;
    public Text txt_Dialogue;
    public RawImage fadeImage;
    public Transform playerTransform;
    public Transform targetTransform;
    

    private float delayTime = 0.8f;
    private float fTickTime;
    private bool isTalk = false;
    private bool isMovable = false;
    private int count = 0;
    public float fadeSpeed = 0.4f;
    public float moveSpeed;

    public enum FadeDirection
    {
        In, // Alpha = 1
        Out // Alpha = 0
    }

    [SerializeField] private Dialogue[] dialogue;

    void Start()
    {
        Invoke("ShowDialogue", 2);
    }

    void Update()
    {
        Talk();
        if (isMovable)
        {
            if (Wait(delayTime))
                transform.position = Vector3.MoveTowards(playerTransform.position, targetTransform.position, moveSpeed * Time.deltaTime);
        }  
    }

    public void Talk()
    {
        if (isTalk)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (count < dialogue.Length)
                {
                    NextDialogue();
                }
                else
                {
                    isMovable = true;
                    OnOff(false);
                }
            }
        }
    }

    public void ShowDialogue()
    {
        OnOff(true);

        count = 0;
        NextDialogue();
    }

    private void OnOff(bool _flag)
    {
        talkPanel.gameObject.SetActive(_flag);
        txt_Dialogue.gameObject.SetActive(_flag);
        isTalk = _flag;
    }

    private void NextDialogue()
    {
        txt_Dialogue.text = dialogue[count].text;
        count++;
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

    public bool Wait(float delayTime)
    {
        fTickTime += Time.deltaTime;
        return (fTickTime >= delayTime);
    }
}
