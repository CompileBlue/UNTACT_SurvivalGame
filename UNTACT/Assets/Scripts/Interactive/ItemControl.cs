using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemControl : MonoBehaviour
{
    public GameObject verticalPanel;
    public GameObject contentPanel;

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
        Interact();
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
    void Interact()
    {
        if (Input.GetKeyDown(KeyCode.F) && isEnter)
        {
            Debug.Log("Press F Button");

            bool isHas = false;
            foreach(var key in PlayerControl.itemList.Keys)
            {
                if(key == itemName)
                {
                    isHas = true;
                    break;
                }
            }
            if (!isHas)
            {
                PlayerControl.itemList.Add(itemName, itemCount);

                GameObject content = Instantiate(contentPanel);
                content.transform.parent = verticalPanel.transform;
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
                count_text.text = PlayerControl.itemList[itemName].ToString();
            }
            else
            {
                PlayerControl.itemList[itemName] += itemCount;

                GameObject content = verticalPanel.transform.FindChild(itemName).gameObject;

                GameObject count = content.transform.GetChild(2).GetChild(0).gameObject;

                TextMeshProUGUI count_text = count.GetComponent<TextMeshProUGUI>();
                count_text.text = PlayerControl.itemList[itemName].ToString();
            }
            Destroy(gameObject);

        }
    }
}
