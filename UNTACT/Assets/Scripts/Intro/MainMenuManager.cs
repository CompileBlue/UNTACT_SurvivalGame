using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    /* File Name : MainMenuManager.cs */

    public Image backGround;
    public InputField inputField;
    public Image fadeImage;
    public Button button;
    public Text text;

    public float animTime = 2.5f;

    private float fadeInStart = 1f;
    private float fadeInEnd = 0f;
    private float fadeInTime = 0f;

    private float fadeOutStart = 0f;
    private float fadeOutEnd = 1f;
    private float fadeOutTime = 0f;

    private bool isClicked = false;
    private bool isEnterName = false;

    public static string playerName;

    private void Update()
    {
        if (isClicked == true)
        {
            if (inputField.text != "")
            {
                isEnterName = true;
                playerName = inputField.text;
                EnterNickName();
            }
            else
            {
                isEnterName = false;
                isClicked = false;
                Debug.Log("이름을 입력하지 않았습니다.");
            }
            /*else
            {
                /*
                switch (EnterNickName())
                {
                    case "409":
                        Debug.Log("이미 중복된 닉네임이 있는 경우");
                        break;

                    case "400":
                        if (EnterNickName.GetMessage().Contains("too long")) Debug.Log("20자 이상의 닉네임인 경우");
                        else if (EnterNickName.GetMessage().Contains("blank")) Debug.Log("닉네임에 앞/뒤 공백이 있는경우");
                        break;

                    default:
                        Debug.Log("서버 공통 에러 발생: " + EnterNickName.GetErrorCode());
                        break;

                }
                */
            //}
        }
    }

    public void LoadNewGameBanner()
    {
        backGround.gameObject.SetActive(true);
    }

    public void SetButtonClicked()
    {
        isClicked = true;
    }

    public void EnterNickName()
    {
        if (isEnterName)
        {
            PlayFadeOut();
            if (fadeImage.color == Color.black)
            {
                SceneManager.LoadScene("Outer_Intro");
            }
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
