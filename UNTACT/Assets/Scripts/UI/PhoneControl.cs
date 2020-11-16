using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class PhoneControl : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject content;

    private Vector2 mouseStart;
    private Vector2 mouseNow;

    public GameObject[] Mode = new GameObject[5]; // 0 : Main, 1 : Health, 2 : Message, 3 : Inventory

    private bool isVibration;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, -240, transform.localPosition.z);
        isVibration = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vibration();
        if (Mode[3].activeSelf)
        {
            foreach (var itemName in PlayerControl.inventoryList.Keys)
            {
                if (PlayerControl.inventoryList[itemName] >= 1)
                {
                    if (!inventoryPanel.transform.FindChild(itemName))
                    {
                        SetItemP(itemName);
                    }
                }
            }
        }
    }
    
    private void OnMouseDrag()
    {
        mouseNow = Input.mousePosition;
        if (transform.localPosition.y <= -120 && mouseNow.y - mouseStart.y > 0)
        {
            transform.localPosition += new Vector3(0, 10f, 0);
        }
        if (transform.localPosition.y >= -220 && mouseNow.y - mouseStart.y < 0)
        {
            transform.localPosition -= new Vector3(0, 10f, 0);
        }
    }
    private void OnMouseDown()
    {
        mouseStart = Input.mousePosition;
    }

    public void HealthBtn()
    {
        Debug.Log("Health");
        int mode = 1;
        for(int i = 0; i < 4; i++)
        {
            Mode[i].SetActive(false);
        }
        Mode[mode].SetActive(true);
    }
    public void ProductionBtn()
    {
        Debug.Log("Production");
    }
    public void MessageBtn()
    {
        Debug.Log("Message");
        int mode = 2;
        for (int i = 0; i < 4; i++)
        {
            Mode[i].SetActive(false);
        }
        Mode[mode].SetActive(true);
    }
    public void InventoryBtn()
    {
        Debug.Log("Inventory"); 
        int mode = 3;
        for (int i = 0; i < 4; i++)
        {
            Mode[i].SetActive(false);
        }
        Mode[mode].SetActive(true);
    }
    public void MainBtn()
    {
        Debug.Log("Main");
        int mode = 0;
        for (int i = 0; i < 4; i++)
        {
            Mode[i].SetActive(false);
        }
        Mode[mode].SetActive(true);
    }

    void SetItemP(string itemName)
    {
        GameObject content_inventory = Instantiate(content);
        content_inventory.transform.parent = inventoryPanel.transform;

        content_inventory.transform.localScale = new Vector3(1f, 1f, 1f);
        content_inventory.name = itemName;

        GameObject icon = content_inventory.transform.GetChild(0).gameObject;
        GameObject name = content_inventory.transform.GetChild(1).gameObject;
        GameObject count = content_inventory.transform.GetChild(2).GetChild(0).gameObject;

        string path = "Item/Icon/" + itemName;
        Image icon_image = icon.GetComponent<Image>();
        icon_image.sprite = Resources.Load<Sprite>(path);

        TextMeshProUGUI name_text = name.GetComponent<TextMeshProUGUI>();
        name_text.text = itemName;

        TextMeshProUGUI count_text = count.GetComponent<TextMeshProUGUI>();
        count_text.text = PlayerControl.inventoryList[itemName].ToString();
    }
    void Vibration ()
    {
        if (isVibration)
        {
            
        }
    }
}
