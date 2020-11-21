using System.Collections;
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

    int recipeNum = 5;

    List<List<string>> recipeList = new List<List<string>>();
    // Start is called before the first frame update
    void Start()
    {
        isEnter = false;

        List<string> recipe = new List<string>();
        recipe.Add("bread");
        recipe.Add("1");
        recipe.Add("banana");
        recipe.Add("2");
        recipeList.Add(recipe);
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
                    if (!laptopPanelR.transform.FindChild(itemCode))
                    {
                        SetItemR_pc(itemCode);
                    }
                }
            }
            foreach (var itemCode in PlayerControl.laptopList.Keys)
            {
                if (PlayerControl.laptopList[itemCode] >= 1)
                {
                    if (!laptopPanelD.transform.FindChild(itemCode))
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
            laptopUI.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape) || !isEnter)
        {
            laptopUI.gameObject.SetActive(false);
        }
    }

    void CheckRecipe()
    {
        
        for (int i = 0; i < recipeList.Count; i++)
        {
            int itemNum = 0;
            foreach (var itemCode in PlayerControl.laptopList.Keys)
            {
                for (int j = 0; j < recipeList[i].Count / 2; j++)
                {
                    if (recipeList[i][j * 2] == itemCode && int.Parse(recipeList[i][j * 2 + 1]) <= PlayerControl.laptopList[itemCode])
                    {
                        itemNum += 1;
                    }
                }
                if(itemNum == recipeList[i].Count / 2)
                {
                    Debug.Log("can make");
                }
            }
            
        }
    }

    void SetItemR_pc(string itemCode)
    {
        GameObject content_down = Instantiate(content);
        content_down.transform.parent = laptopPanelR.transform;

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
        GameObject content_up = Instantiate(content_laptop);
        content_up.transform.parent = laptopPanelD.transform;

        content_up.transform.localScale = new Vector3(1f, 1f, 1f);
        content_up.name = itemCode;

        GameObject icon = content_up;
        GameObject count = content_up.transform.GetChild(0).gameObject;

        string path = "Item/Icon/" + itemCode;
        Image icon_image = icon.GetComponent<Image>();
        icon_image.sprite = Resources.Load<Sprite>(path);

        TextMeshProUGUI count_text = count.GetComponent<TextMeshProUGUI>();
        count_text.text = PlayerControl.laptopList[itemCode].ToString();
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
