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
    public Image playerTalkPanel;
    public Image npcTalkPanel;

    public Text playerTalkText;
    public Text npcTalkText;

    public RawImage fadeImage;

    public Text playerNameText;
    public Text npcNameText;

    public Image phoneUI;

    static string pathInner = @"D:/GitHub/UNTACT_SurvivalGame/UNTACT/Assets/TalkData/TalkData_Inner.txt";
    private string[] allTextsInner = File.ReadAllLines(pathInner);
    private bool isTalk = false;
    private bool isMovable = false;
    public static bool isCalling;

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
    private string[] secretCodes = new string[3];
    private string[] whoTalking = new string[2];

    void Start()
    {
        secretCodes = new string[] { "엄마.", "[전화]", "[전화끝]"};
        whoTalking = new string[] { "주인공", "엄마" };
        isCalling = false;
        playerNameText.text = MainMenuManager.playerName;
        Invoke("ShowDialogue", 1.4f);
    }

    void Update()
    {
        SmartphoneRing();
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
                    Debug.Log("Next");
                }
                else
                {
                    isMovable = true;
                    isCalling = false;
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
        if (_flag == true) // player's object on
        {
            OnOffPanel(playerTalkPanel, npcTalkPanel, _flag);
            OnOffText(playerNameText, npcNameText, _flag);
            OnOffText(playerTalkText, npcTalkText, _flag);

            playerTalkPanel.transform.position = new Vector3(600, -20.22f, 0);
            playerTalkPanel.transform.DOMove(new Vector3(600, 0, 0), 0.5f);

            isTalk = _flag;
        }
        else // npc's object on
        {
            OnOffPanel(playerTalkPanel, npcTalkPanel, _flag);
            OnOffText(playerNameText, npcNameText, _flag);
            OnOffText(playerTalkText, npcTalkText, _flag);

            npcTalkPanel.transform.position = new Vector3(600, -20.22f, 0);
            npcTalkPanel.transform.DOMove(new Vector3(600, 0, 0), 0.5f);

            isTalk = _flag;
        }
    }

    public void OnOffPanel(Image obj, Image other, bool isOnOff)
    {
        obj.gameObject.SetActive(isOnOff);
        other.gameObject.SetActive(!isOnOff);
    }

    public void OnOffText(Text obj, Text other, bool isOnOff)
    {
        obj.gameObject.SetActive(isOnOff);
        other.gameObject.SetActive(!isOnOff);
    }

    private bool CheckCode(int code)
    {
        if (allTextsInner[count].StartsWith(secretCodes[code], System.StringComparison.CurrentCultureIgnoreCase))
        {
            allTextsInner[count] = allTextsInner[count].Replace(secretCodes[code], "");
            return true;
        }
        else
        {
            return false;
        }
    }

    private void NextDialogue()
    {
        isCalling = false;
        allTextsInner[count] = allTextsInner[count].Replace("\\n", "\n");

        if (CheckCode(1)) // Calling
        {
            isTalk = false;
            isCalling = false;
            playerTalkPanel.gameObject.SetActive(false);
            playerNameText.gameObject.SetActive(false);
            playerTalkText.gameObject.SetActive(false);
            Invoke("PhoneAudioPlay", 1.2f);
            // count++;
            // if (allTextsInner[count].StartsWith("엄마.", System.StringComparison.CurrentCultureIgnoreCase))
            // allTextsInner[count] = allTextsInner[count].Replace("엄마.", "");
        }
        else if (CheckCode(2)) // Calling End
        {
            npcTalkPanel.gameObject.SetActive(false);
            npcNameText.gameObject.SetActive(false);
            npcTalkText.gameObject.SetActive(false);
            // count++;
            // allTextsInner[count] = allTextsInner[count].Replace("\\n", "\n");
            Invoke("OnOffAfterCalling", 1f);
        }
        else
        {
            playerTalkText.text = allTextsInner[count];
            OnOff(true);
        }
        
        ++count;
    }

    public void OnOffAfterCalling()
    {
        isCalling = false;
        OnOff(true);
    }

    public void Call()
    {
        isCalling = true;
        isTalk = true;
        if (CheckCode(0))
        {
            npcNameText.text = otherName;
            npcTalkText.text = allTextsInner[count];
            OnOff(false);
        }
        // 이 이상 대화창 진행 안됨. Error
    }

    public void PhoneAudioPlay()
    {
        IntroPhoneControl.audioPlayer.Play();
        isCalling = true;
    }

    public void SmartphoneRing()
    {
        if (phoneUI.transform.position.y > -1.8)
        {
            IntroPhoneControl.audioPlayer.Stop();
        }
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
}