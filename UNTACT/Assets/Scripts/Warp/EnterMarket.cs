using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterMarket : MonoBehaviour
{
    private bool isEnter;
    // Start is called before the first frame update
    void Start()
    {
        
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
            if (SceneManager.GetActiveScene().name == "Main")
            {
                SceneManager.LoadScene("MarketInside");
            }
            else if (SceneManager.GetActiveScene().name == "MarketInside")
            {
                SceneManager.LoadScene("Main");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
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
