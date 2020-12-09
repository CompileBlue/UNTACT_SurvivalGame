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
                SceneManager.LoadScene("Intro");
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

    public void clickEndBtn()
    {
        Application.Quit();
    }
}
