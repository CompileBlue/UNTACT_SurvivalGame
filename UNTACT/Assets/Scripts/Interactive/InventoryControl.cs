using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryControl : MonoBehaviour
{

    public string itemCode;
    public int itemCount;

    private bool isEnter;
    // Start is called before the first frame update
    void Start()
    {
        isEnter = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetItem();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* This conditional sentence is help you to interact with item or object.
         * For example, when you stand in front of the  door, 
         * If you press F button, the door is open.*/
        if (collision.transform.tag == "Player")
        {
            isEnter = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            isEnter = false;
        }
    }
    void GetItem()
    {
        if (Input.GetKeyDown(KeyCode.F) && isEnter)
        {
            bool isHas = false;
            
            foreach (var key in PlayerControl.inventoryList.Keys)
            {
                if(key == itemCode)
                {
                    isHas = true;
                    break;
                }
            }
            if (!isHas)
            {
                if (PlayerControl.inventoryMax > PlayerControl.inventoryNow)
                {
                    PlayerControl.inventoryList.Add(itemCode, itemCount);
                    PlayerControl.refrigeratorList.Add(itemCode, 0);
                    PlayerControl.blueprintList.Add(itemCode, 0);
                    PlayerControl.inventoryNow += 1;

                }
            }
            else
            {
                PlayerControl.inventoryList[itemCode] += itemCount;
            }

            

            Destroy(gameObject);
        }
    }

    
}
