using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaptopControl : MonoBehaviour
{
    public GameObject laptopUI;

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
