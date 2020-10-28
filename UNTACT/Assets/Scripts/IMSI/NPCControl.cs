using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCControl : MonoBehaviour
{
    private bool isEnter;
    // Start is called before the first frame update
    void Start()
    {
        isEnter = false;
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
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
        }
    }
}
