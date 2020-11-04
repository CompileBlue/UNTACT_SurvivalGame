using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorControl : MonoBehaviour
{
    private string isEnter;
    // Start is called before the first frame update
    void Start()
    {
        isEnter = "";

    }

    // Update is called once per frame
    void Update()
    {
        Interact();

    }
    void Interact()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject Player = GameObject.FindWithTag("Player");
            Debug.Log("Press F Button");
            if (isEnter == "HouseDoor_01A")
            {
                SceneManager.LoadScene("OutDoor");
                Debug.Log("Press F Button HouseDoor_01A");
                GameObject Door = GameObject.FindWithTag("HouseDoor_01B");
                Player.transform.position = Door.transform.position;
            }
            if (isEnter == "HouseDoor_01B")
            {
                SceneManager.LoadScene("House");
                Debug.Log("Press F Button HouseDoor_01B");
                GameObject Door = GameObject.FindWithTag("HouseDoor_01A");
                Player.transform.position = Door.transform.position;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* This conditional sentence is help you to interact with item or object.
         * For example, when you stand in front of the  door, 
         * If you press F button, the door is open.*/
        if (collision.transform.tag == "Player")
        {
            if(transform.tag == "HouseDoor_01A")
            {
                Debug.Log("Interact with HouseDoor_01A");
                isEnter = "HouseDoor_01A";
            }
            if (transform.tag == "HouseDoor_01B")
            {
                Debug.Log("Interact with HouseDoor_01B");
                isEnter = "HouseDoor_01B";
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Away from Player");
            isEnter = "";
        }
    }
}
