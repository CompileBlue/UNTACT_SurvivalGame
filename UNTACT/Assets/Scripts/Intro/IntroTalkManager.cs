using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroTalkManager : MonoBehaviour
{
    [Tooltip("인트로 대사 모음")]
    public TextAsset context;
    public Image talkPanel;
    public Text talkText;

    private string m_text;

    int lineSize;
    int count = 0;
    bool isSkipable;

    void Start()
    {
        StartCoroutine(_typing(GetTalk()));
    }

    
    void Update()
    {
        Talk();
    }

    void Talk()
    {
        if (GetTalk() == null)
        {
            talkPanel.gameObject.SetActive(false);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isSkipable == false)
        {
            ++count;
            StartCoroutine(_typing(GetTalk()));
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
