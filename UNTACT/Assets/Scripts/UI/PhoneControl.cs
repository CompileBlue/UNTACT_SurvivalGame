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

    public static AudioSource audioPlayer;
    public AudioClip vibrationAudio;

    public GameObject[] Mode = new GameObject[5]; // 0 : Main, 1 : Health, 2 : Message, 3 : Inventory

    public static bool isVibration;
    public static bool isCall = false;
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        audioPlayer.clip = vibrationAudio;
        audioPlayer.Stop();
        audioPlayer.loop = true;
        audioPlayer.time = 0;
        audioPlayer.volume = 0.5F;

        transform.localPosition = new Vector3(transform.localPosition.x, -290, transform.localPosition.z);
        // isVibration = true;
    }

    // Update is called once per frame
    void Update()
    {
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
            transform.localPosition += new Vector3(0, 20f, 0);
        }
        if (transform.localPosition.y >= -280 && mouseNow.y - mouseStart.y < 0)
        {
            transform.localPosition -= new Vector3(0, 20f, 0);
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
        for (int i = 0; i < 5; i++)
        {
            Mode[i].SetActive(false);
        }
        Mode[mode].SetActive(true);
    }
    public void MessageBtn()
    {
        Debug.Log("Message");
        int mode = 2;
        for (int i = 0; i < 5; i++)
        {
            Mode[i].SetActive(false);
        }
        Mode[mode].SetActive(true);
    }
    public void InventoryBtn()
    {
        Debug.Log("Inventory");
        int mode = 3;
        for (int i = 0; i < 5; i++)
        {
            Mode[i].SetActive(false);
        }
        Mode[mode].SetActive(true);
    }
    public void BankBtn()
    {
        Debug.Log("Bank");
        int mode = 4;
        for (int i = 0; i < 5; i++)
        {
            Mode[i].SetActive(false);
        }
        Mode[mode].SetActive(true);
    }
    public void MainBtn()
    {
        Debug.Log("Main");
        int mode = 0;
        for (int i = 0; i < 5; i++)
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
    public static void Vibration()
    {
        if (isVibration)
        {
            audioPlayer.Play();
        }
        else
        {
            audioPlayer.Stop();
            audioPlayer.time = 0;
        }
    }
}
