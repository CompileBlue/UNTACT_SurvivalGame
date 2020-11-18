using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class InnerIntroManager : MonoBehaviour
{
    public Image talkPanel;
    public Text txt_Dialogue;
    public RawImage fadeImage;
    public RawImage otherNamePanel;
    public Text playerNameText;
    public Text otherNameText;

    static string pathInner = @"D:/GitHub/UNTACT_SurvivalGame/UNTACT/Assets/TalkData/TalkData_Inner.txt";
    private string[] allTextsInner = File.ReadAllLines(pathInner);
    private bool isTalk = false;
    private bool isMovable = false;
    private bool isCalling = false;

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
    public string otherName;

    private bool isMainName = true;

    void Start()
    {
        playerNameText.text = MainMenuManager.playerName;
        Invoke("ShowDialogue", 1.4f);
        // StartCoroutine(Talk());
    }

    void Update()
    {
        PlayFadeIn();
        Talk();
    }

    public void Talk()
    {
        if (isTalk)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (count < allTextsInner.Length)
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
            otherNamePanel.gameObject.SetActive(!_flag);
            otherNameText.gameObject.SetActive(!_flag);
        }
        else
        {
            playerNameText.gameObject.SetActive(_flag);
            otherNamePanel.gameObject.SetActive(!_flag);
            otherNameText.gameObject.SetActive(!_flag);
        }
    }

    private void OnOff(bool _flag)
    {
        talkPanel.gameObject.SetActive(_flag);
        txt_Dialogue.gameObject.SetActive(_flag);
        isTalk = _flag;
    }

    private void NextDialogue()
    {
        allTextsInner[count] = allTextsInner[count].Replace("\\n", "\n");

        if (allTextsInner[count].StartsWith("엄마", System.StringComparison.CurrentCultureIgnoreCase))
        {
            allTextsInner[count] = allTextsInner[count].Replace("엄마.", "");
            otherNameText.text = otherName;
            OnOffNamePanel(false);
        }
        else if (allTextsInner[count].StartsWith("[전화]", System.StringComparison.CurrentCultureIgnoreCase))
        {
            OnOff(false);
            Invoke("SmartphoneRing", 1.5f);
        }
        else
        {
            OnOffNamePanel(true);
        }

        txt_Dialogue.text = allTextsInner[count];
        talkPanel.transform.position = new Vector3(600, -20.22f, 0);
        talkPanel.transform.DOMove(new Vector3(600, 0, 0), 0.5f);
        count++;
    }

    public void SmartphoneRing()
    {
        Debug.Log("Smartphone Ring...");
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

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(2.0f);
    }
}