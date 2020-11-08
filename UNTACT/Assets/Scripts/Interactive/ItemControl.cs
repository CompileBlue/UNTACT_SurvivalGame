using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControl : MonoBehaviour
{
    public GameObject verticalPanel;
    public GameObject contentPanel;

    public int itemCode;
    public int itemCount;

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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* This conditional sentence is help you to interact with item or object.
         * For example, when you stand in front of the  door, 
         * If you press F button, the door is open.*/
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Interact with Player, Item");
            isEnter = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Away from Player, Item");
            isEnter = false;
        }
    }
    void Interact()
    {
        if (Input.GetKeyDown(KeyCode.F) && isEnter)
        {
            Debug.Log("Press F Button");
            PlayerControl.itemList.Add(itemCode, itemCount);
            
            GameObject content = Instantiate(contentPanel);
            content.transform.parent = verticalPanel.transform;
            content.transform.localScale = new Vector3(1f, 1f, 1f);

            GameObject icon = content.transform.GetChild(0).gameObject;
            GameObject name = content.transform.GetChild(0).gameObject;
            GameObject count = content.transform.GetChild(0).gameObject;

            

        }
    }
}
