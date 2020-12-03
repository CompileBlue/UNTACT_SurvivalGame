using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class BluePrintControl : MonoBehaviour
{
    public GameObject blueprintUI;
    public GameObject content;
    public GameObject content_blueprint;
    public GameObject blueprintPanelU;
    public GameObject blueprintPanelD;
    public GameObject blueprintPanelR;
    public GameObject outputBtn;

    private bool isEnter;

    int recipeNum = 5;

    public static List<List<string>> recipeList = new List<List<string>>();
    List<string> canMake = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        isEnter = false;

        CsvReader();
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
        if (isEnter)
        {
            CheckRecipe();
            foreach (var itemCode in PlayerControl.inventoryList.Keys)
            {
                if (PlayerControl.inventoryList[itemCode] >= 1)
                {
                    if (!blueprintPanelR.transform.FindChild(itemCode))
                    {
                        SetItemR_pc(itemCode);
                    }
                }
            }
            foreach (var itemCode in PlayerControl.blueprintList.Keys)
            {
                if (PlayerControl.blueprintList[itemCode] >= 1)
                {
                    if (!blueprintPanelD.transform.FindChild(itemCode))
                    {
                        SetItemD_pc(itemCode);
                    }
                }
            }
        }

    }
    void Interact()
    {
        if (Input.GetKeyDown(KeyCode.F) && isEnter)
        {
            blueprintUI.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape) || !isEnter)
        {
            blueprintUI.gameObject.SetActive(false);
        }
    }

    void CheckRecipe()
    {
        for (int i = 0; i < recipeList.Count - 1; i++)
        {
            int itemNum = 0;
            foreach (var itemCode in PlayerControl.blueprintList.Keys)
            {
                for (int j = 1; j <= int.Parse(recipeList[i][1]); j++)
                {
                    if (recipeList[i][j * 2] == itemCode && int.Parse(recipeList[i][j * 2 + 1]) <= PlayerControl.blueprintList[itemCode])
                    {
                        itemNum += 1;
                    }
                }
                if (itemNum == int.Parse(recipeList[i][1]))
                {
                    bool isCanMake = true;
                    for (int j = 0; j < canMake.Count; j++)
                    {
                        if (recipeList[i][0] == canMake[j])
                        {
                            isCanMake = false;
                            break;
                        }
                    }
                    if (isCanMake)
                    {
                        canMake.Add(recipeList[i][0]);
                    }
                    makeOutput(canMake[canMake.Count - 1]);
                }
                else
                {
                    canMake.Remove(recipeList[i][0]);
                    makeOutput("");
                }
            }

        }
    }

    void makeOutput(string itemCode)
    {
        if (itemCode == "")
        {
            Image icon_image = outputBtn.GetComponent<Image>();
            icon_image.sprite = null;
        }
        else
        {
            string path = "Item/Icon/" + itemCode;
            Image icon_image = outputBtn.GetComponent<Image>();
            icon_image.sprite = Resources.Load<Sprite>(path);
        }
    }

    public void clickOutput()
    {
        string itemCode = outputBtn.GetComponent<Image>().sprite.name;
        bool isHas = false;

        foreach (var key in PlayerControl.inventoryList.Keys)
        {
            if (key == itemCode)
            {
                isHas = true;
                break;
            }
        }
        if (!isHas)
        {
            if (PlayerControl.inventoryMax > PlayerControl.inventoryNow)
            {
                PlayerControl.inventoryList.Add(itemCode, 1);
                PlayerControl.refrigeratorList.Add(itemCode, 0);
                PlayerControl.blueprintList.Add(itemCode, 0);
                PlayerControl.inventoryNow += 1;
                for (int i = 0; i < recipeList.Count; i++)
                {
                    if (recipeList[i][0] == itemCode)
                    {
                        for (int j = 1; j <= int.Parse(recipeList[i][1]); j++)
                        {
                            PlayerControl.blueprintList[recipeList[i][j * 2]] -= int.Parse(recipeList[i][j * 2 + 1]);
                        }
                    }
                }
            }
        }
        else
        {
            PlayerControl.inventoryList[itemCode] += 1;
            for (int i = 0; i < recipeList.Count; i++)
            {
                if (recipeList[i][0] == itemCode)
                {
                    for (int j = 1; j <= int.Parse(recipeList[i][1]); j++)
                    {
                        PlayerControl.blueprintList[recipeList[i][j * 2]] -= int.Parse(recipeList[i][j * 2 + 1]);
                    }
                }
            }
        }

    }

    void SetItemR_pc(string itemCode)
    {
        GameObject content_down = Instantiate(content);
        content_down.transform.parent = blueprintPanelR.transform;

        content_down.transform.localScale = new Vector3(1f, 1f, 1f);
        content_down.name = itemCode;

        GameObject icon = content_down.transform.GetChild(0).gameObject;
        GameObject name = content_down.transform.GetChild(1).gameObject;
        GameObject count = content_down.transform.GetChild(2).GetChild(0).gameObject;

        string path = "Item/Icon/" + itemCode;
        Image icon_image = icon.GetComponent<Image>();
        icon_image.sprite = Resources.Load<Sprite>(path);

        TextMeshProUGUI name_text = name.GetComponent<TextMeshProUGUI>();
        name_text.text = PlayerControl.itemList[int.Parse(itemCode)][1];

        TextMeshProUGUI count_text = count.GetComponent<TextMeshProUGUI>();
        count_text.text = PlayerControl.inventoryList[itemCode].ToString();
    }

    void SetItemD_pc(string itemCode)
    {
        GameObject content_up = Instantiate(content_blueprint);
        content_up.transform.parent = blueprintPanelD.transform;

        content_up.transform.localScale = new Vector3(1f, 1f, 1f);
        content_up.name = itemCode;

        GameObject icon = content_up;
        GameObject count = content_up.transform.GetChild(0).gameObject;

        string path = "Item/Icon/" + itemCode;
        Image icon_image = icon.GetComponent<Image>();
        icon_image.sprite = Resources.Load<Sprite>(path);

        TextMeshProUGUI count_text = count.GetComponent<TextMeshProUGUI>();
        count_text.text = PlayerControl.blueprintList[itemCode].ToString();
    }

    void SetItemU_pc()
    {
        // item output
    }
    void CsvReader()
    {
        var reader = new StreamReader(File.OpenRead(@"../UNTACT/Assets/Resources/Item/makeList.csv"));

        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(',');
            List<string> list = new List<string>();
            foreach (var content in values)
            {
                list.Add(content);
            }
            recipeList.Add(list);
        }
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
