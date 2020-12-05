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
            foreach (var itemCode in PlayerControl.refrigeratorList.Keys)
            {
                if (PlayerControl.refrigeratorList[itemCode] >= 1)
                {
                    if (!refrigeratorPanelL.transform.FindChild(itemCode))
                    {
                        SetItemL(itemCode);
                    }
                }
            }
            foreach (var itemCode in PlayerControl.inventoryList.Keys)
            {
                if (PlayerControl.inventoryList[itemCode] >= 1)
                {
                    if (!refrigeratorPanelR.transform.FindChild(itemCode))
                    {
                        SetItemR(itemCode);
                    }
                }
            }
        }
    }
    void Interact()
    {
        if (Input.GetKeyDown(KeyCode.F) && isEnter)
        {
            refrigeratorUI.gameObject.SetActive(true);
            

        }
        if (Input.GetKeyDown(KeyCode.Escape) || !isEnter)
        {
            refrigeratorUI.gameObject.SetActive(false);
        }
    }

    void SetItemL(string itemCode)
    {
        GameObject content_refrigerator = Instantiate(content);
        content_refrigerator.transform.parent = refrigeratorPanelL.transform;

        content_refrigerator.transform.localScale = new Vector3(1f, 1f, 1f);
        content_refrigerator.name = itemCode;

        GameObject icon = content_refrigerator.transform.GetChild(0).gameObject;
        GameObject name = content_refrigerator.transform.GetChild(1).gameObject;
        GameObject count = content_refrigerator.transform.GetChild(2).GetChild(0).gameObject;

        string path = "Item/Icon/" + itemCode;
        Image icon_image = icon.GetComponent<Image>();
        icon_image.sprite = Resources.Load<Sprite>(path);

        TextMeshProUGUI name_text = name.GetComponent<TextMeshProUGUI>();
        name_text.text = PlayerControl.itemList[int.Parse(itemCode)][1];

        TextMeshProUGUI count_text = count.GetComponent<TextMeshProUGUI>();
        count_text.text = PlayerControl.refrigeratorList[itemCode].ToString();
    }
    void SetItemR(string itemCode)
    {
        GameObject content_refrigerator = Instantiate(content);
        content_refrigerator.transform.parent = refrigeratorPanelR.transform;

        content_refrigerator.transform.localScale = new Vector3(1f, 1f, 1f);
        content_refrigerator.name = itemCode;

        GameObject icon = content_refrigerator.transform.GetChild(0).gameObject;
        GameObject name = content_refrigerator.transform.GetChild(1).gameObject;
        GameObject count = content_refrigerator.transform.GetChild(2).GetChild(0).gameObject;

        string path = "Item/Icon/" + itemCode;
        Image icon_image = icon.GetComponent<Image>();
        icon_image.sprite = Resources.Load<Sprite>(path);

        TextMeshProUGUI name_text = name.GetComponent<TextMeshProUGUI>();
        name_text.text = PlayerControl.itemList[int.Parse(itemCode)][1];

        TextMeshProUGUI count_text = count.GetComponent<TextMeshProUGUI>();
        count_text.text = PlayerControl.inventoryList[itemCode].ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* This conditional sentence is help you to interact with item or object.
         * For example, when you stand in front of the  door, 
         * If you press F button, the door is open.*/
        if (collision.transform.name == "Refrigerator")
        {
            isEnter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.name == "Refrigerator")
        {
            isEnter = false;
        }
    }
}
