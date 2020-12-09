using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreateCharacterManager : MonoBehaviour
{
    public InputField inputField;
    public Image fadeImage;
    public Button button;

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
            if (CheckNickName())
            {
                isEnterName = true;
                playerName = inputField.text;
                EnterNickName();
            }
            else
            {
                isEnterName = false;
                isClicked = false;
                Debug.Log("잘못된 닉네임입니다. 다시 입력해 주세요.");
            }
        }
    }

    private bool CheckNickName()
    {
        if (Regex.IsMatch(inputField.text, "^[0-9a-zA-z가-힣]*$") && inputField.text != "" && inputField.text.Contains("blank") != true && inputField.text.Length <= 8)
            return true; // nickname check
        else
            return false;
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
