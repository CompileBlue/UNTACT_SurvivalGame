﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LaptopControl : MonoBehaviour
{
    public GameObject laptopUI;
    public GameObject content;
    public GameObject content_laptop;
    public GameObject laptopPanelU;
    public GameObject laptopPanelD;
    public GameObject laptopPanelR;

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
        foreach (var itemName in PlayerControl.inventoryList.Keys)
        {
            if (PlayerControl.inventoryList[itemName] >= 1)
            {
                Debug.Log(itemName);
                if (!laptopPanelR.transform.FindChild(itemName))
                {
                    SetItemR_pc(itemName);
                }
            }
        }
        foreach (var itemName in PlayerControl.laptopList.Keys)
        {
            if (PlayerControl.laptopList[itemName] >= 1)
            {
                Debug.Log(itemName);
                if (!laptopPanelD.transform.FindChild(itemName))
                {
                    SetItemD_pc(itemName);
                }
            }
        }
    }
    void Interact()
    {
        if (Input.GetKeyDown(KeyCode.F) && isEnter)
        {
            Debug.Log("Open Laptop.");
            laptopUI.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape) || !isEnter)
        {
            laptopUI.gameObject.SetActive(false);
        }
    }

    void SetItemR_pc(string itemName)
    {
        GameObject content_down = Instantiate(content);
        content_down.transform.parent = laptopPanelR.transform;

        content_down.transform.localScale = new Vector3(1f, 1f, 1f);
        content_down.name = itemName;

        GameObject icon = content_down.transform.GetChild(0).gameObject;
        GameObject name = content_down.transform.GetChild(1).gameObject;
        GameObject count = content_down.transform.GetChild(2).GetChild(0).gameObject;

        string path = "Item/Icon/" + itemName;
        Image icon_image = icon.GetComponent<Image>();
        icon_image.sprite = Resources.Load<Sprite>(path);

        TextMeshProUGUI name_text = name.GetComponent<TextMeshProUGUI>();
        name_text.text = itemName;

        TextMeshProUGUI count_text = count.GetComponent<TextMeshProUGUI>();
        count_text.text = PlayerControl.inventoryList[itemName].ToString();
    }

    void SetItemD_pc(string itemName)
    {
        GameObject content_up = Instantiate(content_laptop);
        content_up.transform.parent = laptopPanelD.transform;

        content_up.transform.localScale = new Vector3(1f, 1f, 1f);
        content_up.name = itemName;

        GameObject icon = content_up;
        GameObject count = content_up.transform.GetChild(0).gameObject;

        string path = "Item/Icon/" + itemName;
        Image icon_image = icon.GetComponent<Image>();
        icon_image.sprite = Resources.Load<Sprite>(path);

        TextMeshProUGUI count_text = count.GetComponent<TextMeshProUGUI>();
        count_text.text = PlayerControl.laptopList[itemName].ToString();
    }

    void SetItemU_pc()
    {
        // item output
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