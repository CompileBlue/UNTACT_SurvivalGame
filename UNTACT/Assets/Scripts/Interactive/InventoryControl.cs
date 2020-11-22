using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryControl : MonoBehaviour
{

    public string itemName;
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
            Debug.Log("Interact with Player, Item");
            isEnter = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Away from Player, Item");
            isEnter = false;
        }
    }
    void GetItem()
    {
        if (Input.GetKeyDown(KeyCode.F) && isEnter)
        {
            Debug.Log("Press F Button");
            bool isHas = false;
            
            foreach (var key in PlayerControl.inventoryList.Keys)
            {
                if(key == itemName)
                {
                    isHas = true;
                    break;
                }
            }
            if (!isHas)
            {
                if (PlayerControl.inventoryMax > PlayerControl.inventoryNow)
                {
                    PlayerControl.inventoryList.Add(itemName, itemCount);
                    PlayerControl.refrigeratorList.Add(itemName, 0);
                    PlayerControl.laptopList.Add(itemName, 0);
                    PlayerControl.inventoryNow += 1;

                }
            }
            else
            {
                PlayerControl.inventoryList[itemName] += itemCount;
            }

            

            Destroy(gameObject);
        }
    }

    
}
