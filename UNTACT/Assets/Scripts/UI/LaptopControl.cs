using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class LaptopControl : MonoBehaviour
{
    public GameObject screen;
    public TextMeshProUGUI bottomText;

    private string bottomContent = "전국적으로 원인 불명의 바이러스가 전국적으로 원인 불명의 바이러스가 전국적으로 원인 불명의 바이러스가 전국적으로 원인 불명의 바이러스가";
    private bool isEnter;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        bottomText.text = bottomContent;

    }

    // Update is called once per frame
    void Update()
    {
        if (screen.active)
        {
            timer += Time.deltaTime;
            if (timer >= 0.3f)
            {
                timer = 0;
                bottomContent = bottomContent.Substring(1, bottomContent.Length - 1) + bottomContent.Substring(0, 1);
                bottomText.text = bottomContent;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.F) && isEnter)
        {
            screen.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape) || !isEnter)
        {
            screen.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Laptop")
        {
            isEnter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.name == "Laptop")
        {
            isEnter = false;
        }
    }
}
