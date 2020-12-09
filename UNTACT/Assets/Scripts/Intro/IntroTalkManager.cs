using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroTalkManager : MonoBehaviour
{
    private MainMenuManager mainMenuManager;

    public TextAsset context;

    public Image talkPanel;
    public Text talkText;
    public Image introDiagram;
    public Image fadeInImage;
    public Sprite[] dialogues = new Sprite[4];

    private AudioSource audioPlayer;
    public AudioClip audio;
    public Camera mainCamera;
    private AudioSource bgm;

    int lineSize;
    int count = 0;
    bool isOneShot = false;
    float start;
    float end;
    float time;

    void Start()
    {
        FadeInAnim();
        audioPlayer = GetComponent<AudioSource>();
        bgm = mainCamera.GetComponent<AudioSource>();
        StartCoroutine(_typing(GetTalk()));
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("HouseInside");
        }
        LoadDialogue();
        Talk();
    }

    void FadeInAnim()
    {
        StartCoroutine("FadeIn");
    }

    IEnumerator FadeIn()
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

    void LoadDialogue()
    {
        if (count == 0)
        {
            introDiagram.sprite = dialogues[0];
        }
        else if (count == 2)
        {
            introDiagram.sprite = dialogues[1];
        }
        else if (count == 4)
        {
            introDiagram.sprite = dialogues[2];
        }
        else if (count == 7)
        {
            introDiagram.sprite = dialogues[3];
        }
    }

    void Talk()
    {
        if (fadeInImage.color.a == 0)
        {
            if (GetTalk() == null)
            {
                talkPanel.gameObject.SetActive(false);
                return;
            }

            if (talkText.text == GetTalk() && Input.GetKeyDown(KeyCode.Space))
            {
                ++count;
                StartCoroutine(_typing(GetTalk()));
            }

            if (count == 7 && isOneShot == false)
            {
                isOneShot = true;
                bgm.Stop();
                audioPlayer.PlayOneShot(audio, 0.1F);
            }
            if (count == 8)
            {
                audioPlayer.Stop();
                SceneManager.LoadScene("HouseInside");
            }
        }
    }

    string GetTalk()
    {
        string currentText = context.text.Substring(0, context.text.Length - 1);
        string[] line = currentText.Split('\n');

        lineSize = line.Length;

        if (count == lineSize)
            return null;

        line[count] = line[count].Replace("\\n", "\n");

        return line[count];
    }

    IEnumerator _typing(string m_text)
    {
        for (int i = 0; i <= m_text.Length; i++)
        {
            talkText.text = m_text.Substring(0, i);

            yield return new WaitForSeconds(0.04f);
        }
    }
}
