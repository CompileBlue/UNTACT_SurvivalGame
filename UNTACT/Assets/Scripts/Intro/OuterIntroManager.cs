using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class OuterIntroManager : MonoBehaviour
{
    public Image talkPanel;
    public Text txt_Dialogue;
    public RawImage fadeImage;
    public Transform playerTransform;
    public Transform targetTransform;
    public Text playerNameText;

    static string pathOuter = @"D:/GitHub/UNTACT_SurvivalGame/UNTACT/Assets/TalkData/TalkData_Outer.txt";
    private string[] allTextsOuter = File.ReadAllLines(pathOuter);
    private bool isTalk = false;
    private bool isMovable = false;

    private float delayTime = 0.8f;
    private float fTickTime;
    private int count = 0;
    public float moveSpeed;

    public float animTime = 2f;

    private float fadeInStart = 1f;
    private float fadeInEnd = 0f;
    private float fadeInTime = 0f;

    private float fadeOutStart = 0f;
    private float fadeOutEnd = 1f;
    private float fadeOutTime = 0f;

    public string sceneName;
    private string playerName;

    void Start()
    {
        playerNameText.text = MainMenuManager.playerName;
        Invoke("ShowDialogue", 1.2f);
    }

    void Update()
    {
        PlayFadeIn();
        Talk();
        if (isMovable)
        {
            if (Wait(delayTime))
            {
                transform.position = Vector3.MoveTowards(playerTransform.position, targetTransform.position, moveSpeed * Time.deltaTime);
                if (transform.position == targetTransform.position)
                {
                    PlayFadeOut();
                    if (fadeImage.color == Color.black)
                        LoadScene();
                }
            }
        }
    }

    public static void LoadScene()
    {
        SceneManager.LoadScene("Inner_Intro");
    }

    public void Talk()
    {
        if (isTalk)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (count < allTextsOuter.Length)
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
        talkPanel.transform.DOMove(new Vector3(600, 0, 0), 0.5f);

        count = 0;
        NextDialogue();
    }

    private void OnOffNamePanel(bool _flag)
    {
        if (_flag == true)
        {
            playerNameText.gameObject.SetActive(_flag);
        }
        else
        {
            playerNameText.gameObject.SetActive(_flag);
        }
        // isMainName = _flag;
    }

    private void OnOff(bool _flag)
    {
        talkPanel.gameObject.SetActive(_flag);
        txt_Dialogue.gameObject.SetActive(_flag);
        isTalk = _flag;
    }

    private void NextDialogue()
    {
        OnOffNamePanel(true);
        allTextsOuter[count] = allTextsOuter[count].Replace("\\n", "\n");
        txt_Dialogue.text = allTextsOuter[count];
        talkPanel.transform.position = new Vector3(600, -20.22f, 0);
        talkPanel.transform.DOMove(new Vector3(600, 0, 0), 0.5f);
        count++;
    }

    public void PlayFadeIn()
    {
        fadeInTime += Time.deltaTime / animTime;
        Color color = fadeImage.color;
        color.a = Mathf.Lerp(fadeInStart, fadeInEnd, fadeInTime);
        fadeImage.color = color;
    }

    public void PlayFadeOut()
    {
        fadeOutTime += Time.deltaTime / animTime;
        Color color = fadeImage.color;
        color.a = Mathf.Lerp(fadeOutStart, fadeOutEnd, fadeOutTime);
        fadeImage.color = color;
    }

    public bool Wait(float delayTime)
    {
        fTickTime += Time.deltaTime;
        return (fTickTime >= delayTime);
    }
}
