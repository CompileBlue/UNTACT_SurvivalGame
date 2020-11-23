using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemButtonControl : MonoBehaviour
{
    public TextMeshProUGUI count_text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.parent.parent.parent.name == "ScrollPanel_P")
        {
            count_text.text = PlayerControl.inventoryList[transform.parent.name].ToString();
            if (PlayerControl.inventoryList[transform.parent.name] <= 0)
            {
                Destroy(transform.parent.gameObject);
                PlayerControl.inventoryNow -= 1;
            }
        }
        else if (transform.parent.parent.parent.name == "ScrollPanel_R")
        {
            count_text.text = PlayerControl.inventoryList[transform.parent.name].ToString();
            if (PlayerControl.inventoryList[transform.parent.name] <= 0)
            {
                Destroy(transform.parent.gameObject);
                PlayerControl.inventoryNow -= 1;
            }

        }
        else if (transform.parent.parent.parent.name == "ScrollPanel_L")
        {
            count_text.text = PlayerControl.refrigeratorList[transform.parent.name].ToString();
            if (PlayerControl.refrigeratorList[transform.parent.name] <= 0)
            {
                Destroy(transform.parent.gameObject);
            }
        }
        else if (transform.parent.parent.parent.name == "ScrollPanel_R_pc")
        {
            count_text.text = PlayerControl.inventoryList[transform.parent.name].ToString();
            if (PlayerControl.inventoryList[transform.parent.name] <= 0)
            {
                Destroy(transform.parent.gameObject);
                PlayerControl.inventoryNow -= 1;
            }

        }
        else if (transform.parent.parent.name == "ScrollPanel_D_pc")
        {
            count_text.text = PlayerControl.laptopList[transform.name].ToString();
            if (PlayerControl.laptopList[transform.name] <= 0)
            {
                Destroy(transform.gameObject);
            }

        }
    }
    public void ClickItem()
    {
        if (transform.parent.parent.parent.name == "ScrollPanel_P")
        {
            PhoneItem();
        }else if (transform.parent.parent.parent.name == "ScrollPanel_R")
        {
            RefrigeratorR();
        }
        else if (transform.parent.parent.parent.name == "ScrollPanel_L")
        {
            RefrigeratorL();
        }
        else if (transform.parent.parent.parent.name == "ScrollPanel_R_pc")
        {
            RefrigeratorR_pc();
        }
        else if (transform.parent.parent.name == "ScrollPanel_D_pc")
        {
            RefrigeratorD_pc();
        }

    }
    void PhoneItem()
    {
        if (PlayerControl.inventoryList[transform.parent.name] >= 1)
        {
            PlayerControl.inventoryList[transform.parent.name] -= 1;
            PlayerControl.satiation += 10;
        }
    }
    void RefrigeratorR()
    {
        if (PlayerControl.inventoryList[transform.parent.name] >= 1)
        {
            PlayerControl.inventoryList[transform.parent.name] -= 1;
            PlayerControl.refrigeratorList[transform.parent.name] += 1;

        }
    }
    void RefrigeratorL()
    {
        if (PlayerControl.refrigeratorList[transform.parent.name] >= 1)
        {
            PlayerControl.refrigeratorList[transform.parent.name] -= 1;
            PlayerControl.inventoryList[transform.parent.name] += 1;
        }
    }
    void RefrigeratorR_pc()
    {
        if (PlayerControl.inventoryList[transform.parent.name] >= 1)
        {
            PlayerControl.inventoryList[transform.parent.name] -= 1;
            PlayerControl.laptopList[transform.parent.name] += 1;
        }
    }
    void RefrigeratorD_pc()
    {
        if (PlayerControl.laptopList[transform.name] >= 1)
        {
            PlayerControl.laptopList[transform.name] -= 1;
            PlayerControl.inventoryList[transform.name] += 1;
        }
    }
   
}
