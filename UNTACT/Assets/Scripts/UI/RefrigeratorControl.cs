using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RefrigeratorControl : MonoBehaviour
{
    public GameObject refrigeratorUI;
    public GameObject content;
    public GameObject refrigeratorPanelL;
    public GameObject refrigeratorPanelR;

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
        if (isEnter)
        {
            foreach (var itemName in PlayerControl.refrigeratorList.Keys)
            {
                if (PlayerControl.refrigeratorList[itemName] >= 1)
                {
                    if (!refrigeratorPanelL.transform.FindChild(itemName))
                    {
                        SetItemL(itemName);
                    }
                }
            }
            foreach (var itemName in PlayerControl.inventoryList.Keys)
            {
                if (PlayerControl.inventoryList[itemName] >= 1)
                {
                    Debug.Log(itemName);
                    if (!refrigeratorPanelR.transform.FindChild(itemName))
                    {
                        SetItemR(itemName);
                    }
                }
            }
        }
    }
    void Interact()
    {
        if (Input.GetKeyDown(KeyCode.F) && isEnter)
        {
            Debug.Log("Open Refrigerator.");
            refrigeratorUI.gameObject.SetActive(true);
            

        }
        if (Input.GetKeyDown(KeyCode.Escape) || !isEnter)
        {
            refrigeratorUI.gameObject.SetActive(false);
        }
    }

    void SetItemL(string itemName)
    {
        GameObject content_refrigerator = Instantiate(content);
        content_refrigerator.transform.parent = refrigeratorPanelL.transform;

        content_refrigerator.transform.localScale = new Vector3(1f, 1f, 1f);
        content_refrigerator.name = itemName;

        GameObject icon = content_refrigerator.transform.GetChild(0).gameObject;
        GameObject name = content_refrigerator.transform.GetChild(1).gameObject;
        GameObject count = content_refrigerator.transform.GetChild(2).GetChild(0).gameObject;

        string path = "Item/Icon/" + itemName;
        Image icon_image = icon.GetComponent<Image>();
        icon_image.sprite = Resources.Load<Sprite>(path);

        TextMeshProUGUI name_text = name.GetComponent<TextMeshProUGUI>();
        name_text.text = itemName;

        TextMeshProUGUI count_text = count.GetComponent<TextMeshProUGUI>();
        count_text.text = PlayerControl.refrigeratorList[itemName].ToString();
    }
    void SetItemR(string itemName)
    {
        GameObject content_refrigerator = Instantiate(content);
        content_refrigerator.transform.parent = refrigeratorPanelR.transform;

        content_refrigerator.transform.localScale = new Vector3(1f, 1f, 1f);
        content_refrigerator.name = itemName;

        GameObject icon = content_refrigerator.transform.GetChild(0).gameObject;
        GameObject name = content_refrigerator.transform.GetChild(1).gameObject;
        GameObject count = content_refrigerator.transform.GetChild(2).GetChild(0).gameObject;

        string path = "Item/Icon/" + itemName;
        Image icon_image = icon.GetComponent<Image>();
        icon_image.sprite = Resources.Load<Sprite>(path);

        TextMeshProUGUI name_text = name.GetComponent<TextMeshProUGUI>();
        name_text.text = itemName;

        TextMeshProUGUI count_text = count.GetComponent<TextMeshProUGUI>();
        count_text.text = PlayerControl.inventoryList[itemName].ToString();
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
}
