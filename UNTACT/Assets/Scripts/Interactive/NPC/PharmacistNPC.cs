using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PharmacistNPC : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.F) && isEnter)
        {
            Interact();
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
        // 텍스트는 재영씨가 ^^

        PlayerControl.money -= 1000;

        string itemCode = "8"; // 구급상자
        bool isHas = false;

        foreach (var key in PlayerControl.inventoryList.Keys)
        {
            if (key == itemCode)
            {
                isHas = true;
                break;
            }
        }

        if (!isHas)
        {
            if (PlayerControl.inventoryMax > PlayerControl.inventoryNow)
            {
                PlayerControl.inventoryList.Add(itemCode, 1);
                PlayerControl.refrigeratorList.Add(itemCode, 0);
                PlayerControl.laptopList.Add(itemCode, 0);
                PlayerControl.inventoryNow += 1;
            }
        }
        else
        {
            PlayerControl.inventoryList[itemCode] += 1;
        }
    }
}
