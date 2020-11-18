using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCControl : MonoBehaviour
{
    public Image talkPanel;
    public Text txt_Dialogue;
    public Text NameText;

    private bool isEnter;
    public static bool isTalk = false;
    private bool isActive = false;
    private int count;
    private float NPCSpeed;

    void Start()
    {
        isEnter = false;
    }

    void Update()
    {
        Interact();
        Talk();
        NPCMove();
    }

    public void NPCMove()
    {
        if (!isTalk)
        {
            NPCSpeed = 2f;
            transform.Translate(Vector3.right * NPCSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            NPCSpeed = 0f;
            transform.Translate(Vector3.right * NPCSpeed * Time.deltaTime, Space.World);
        }
    }

    public void Talk()
    {
        if (isTalk)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (count < 1)
                {
                    NextDialogue();
                }
                else
                {
                    OnOff(false);
                    OnOffNamePanel(false);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* This conditional sentence is help you to interact with NPC.
         * For example, when you stand in front of the some NPC, 
         * If you press F button, you can talk with some NPC.*/
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Interact with Player, NPC");
            isEnter = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Away from Player, NPC");
            isEnter = false;
        }
    }

    void Interact()
    {
        if (Input.GetKeyDown(KeyCode.F) && isEnter)
        {
            Debug.Log("Press F Button");
            ShowDialogue();
        }
    }

    public void ShowDialogue()
    {
        isActive = false;

        if (isActive != true)
        {
            OnOff(true);
            OnOffNamePanel(true);
            txt_Dialogue.text = "콜록! 콜록!";
            talkPanel.transform.DOMove(new Vector3(600, 0, 0), 0.5f);

            count = 0;
            NextDialogue();
        }

        isActive = true;
    }

    public void NextDialogue()
    {
        talkPanel.transform.position = new Vector3(600, -20.22f, 0);
        talkPanel.transform.DOMove(new Vector3(600, 0, 0), 0.5f);
        ++count;
    }

    private void OnOff(bool _flag)
    {
        talkPanel.gameObject.SetActive(_flag);
        txt_Dialogue.gameObject.SetActive(_flag);
        isTalk = _flag;
    }

    private void OnOffNamePanel(bool _flag)
    {
        if (_flag == true)
        {
            NameText.gameObject.SetActive(_flag);
        }
        else
        {
            NameText.gameObject.SetActive(_flag);
        }
    }
}
