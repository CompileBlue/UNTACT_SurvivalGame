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

    private AudioSource audioPlayer;
    public AudioClip vibrationAudio;

    public GameObject[] Mode = new GameObject[5]; // 0 : Main, 1 : Health, 2 : Message, 3 : Inventory

    private bool isVibration;
    private bool isCall;
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
        isVibration = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mode[3].activeSelf)
        {
            foreach (var itemCode in PlayerControl.inventoryList.Keys)
            {
                if (PlayerControl.inventoryList[itemCode] >= 1)
                {
                    if (!inventoryPanel.transform.FindChild(itemCode.ToString()))
                    {
                        SetItemP(itemCode);
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
        int mode = 1;
        for(int i = 0; i < 5; i++)
        {
            Mode[i].SetActive(false);
        }
        Mode[mode].SetActive(true);
    }
    public void MessageBtn()
    {
        int mode = 2;
        for (int i = 0; i < 5; i++)
        {
            Mode[i].SetActive(false);
        }
        Mode[mode].SetActive(true);
    }
    public void InventoryBtn()
    {
        int mode = 3;
        for (int i = 0; i < 5; i++)
        {
            Mode[i].SetActive(false);
        }
        Mode[mode].SetActive(true);
    }
    public void BankBtn()
    {
        int mode = 4;
        for (int i = 0; i < 5; i++)
        {
            Mode[i].SetActive(false);
        }
        Mode[mode].SetActive(true);
    }
    public void MainBtn()
    {
        int mode = 0;
        for (int i = 0; i < 5; i++)
        {
            Mode[i].SetActive(false);
        }
        Mode[mode].SetActive(true);
    }

    void SetItemP(string itemCode)
    {
        GameObject content_inventory = Instantiate(content);
        content_inventory.transform.parent = inventoryPanel.transform;

        content_inventory.transform.localScale = new Vector3(1f, 1f, 1f);
        content_inventory.name = itemCode;

        GameObject icon = content_inventory.transform.GetChild(0).gameObject;
        GameObject name = content_inventory.transform.GetChild(1).gameObject;
        GameObject count = content_inventory.transform.GetChild(2).GetChild(0).gameObject;

        string path = "Item/Icon/" + itemCode;
        Image icon_image = icon.GetComponent<Image>();
        icon_image.sprite = Resources.Load<Sprite>(path);

        TextMeshProUGUI name_text = name.GetComponent<TextMeshProUGUI>();
        name_text.text = PlayerControl.itemList[int.Parse(itemCode)][1];

        TextMeshProUGUI count_text = count.GetComponent<TextMeshProUGUI>();
        count_text.text = PlayerControl.inventoryList[itemCode].ToString();
    }
    void Vibration ()
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
