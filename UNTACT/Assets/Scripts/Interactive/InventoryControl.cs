using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryControl : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject refrigeratorPanel;
    public GameObject content;

    SpriteRenderer icon_spriteRenderer;

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
            foreach(var key in PlayerControl.inventoryList.Keys)
            {
                if(key == itemName)
                {
                    isHas = true;
                    break;
                }
            }
            if (!isHas)
            {
                if(PlayerControl.inventoryMax > PlayerControl.inventoryNow)
                {
                    PlayerControl.inventoryList.Add(itemName, itemCount);
                    PlayerControl.inventoryNow += 1;

                    GameObject content_inventory = Instantiate(content);
                    GameObject content_refrigerator = Instantiate(content);

                    SetItem(content_inventory, 0);
                    SetItem(content_refrigerator, 1);

                    Destroy(gameObject);
                }
            }
            else
            {
                PlayerControl.inventoryList[itemName] += itemCount;

                GameObject content1 = inventoryPanel.transform.FindChild(itemName).gameObject;
                GameObject content2 = refrigeratorPanel.transform.FindChild(itemName).gameObject;

                GameObject count1 = content1.transform.GetChild(2).GetChild(0).gameObject;
                GameObject count2 = content2.transform.GetChild(2).GetChild(0).gameObject;

                TextMeshProUGUI count_text1 = count1.GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI count_text2 = count2.GetComponent<TextMeshProUGUI>();

                count_text1.text = PlayerControl.inventoryList[itemName].ToString();
                count_text2.text = PlayerControl.inventoryList[itemName].ToString();

                Destroy(gameObject);
            }

        }
    }

    void SetItem(GameObject content, int mode)
    {
        content.transform.parent =  (mode == 0) ? inventoryPanel.transform: refrigeratorPanel.transform;

        content.transform.localScale = new Vector3(1f, 1f, 1f);
        content.name = itemName;

        GameObject icon = content.transform.GetChild(0).gameObject;
        GameObject name = content.transform.GetChild(1).gameObject;
        GameObject count = content.transform.GetChild(2).GetChild(0).gameObject;

        string path = "Item/Icon/" + itemName;
        Image icon_image = icon.GetComponent<Image>();
        icon_image.sprite = Resources.Load<Sprite>(path);

        TextMeshProUGUI name_text = name.GetComponent<TextMeshProUGUI>();
        name_text.text = itemName;

        TextMeshProUGUI count_text = count.GetComponent<TextMeshProUGUI>();
        count_text.text = PlayerControl.inventoryList[itemName].ToString();

    }
}
