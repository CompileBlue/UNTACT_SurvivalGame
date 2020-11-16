using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class PhoneControl : MonoBehaviour
{
    private Vector2 mouseStart;
    private Vector2 mouseNow;

    public GameObject[] Mode = new GameObject[5]; // 0 : Main, 1 : Health, 2 : Message, 3 : Inventory

    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, -240, transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {

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
}
