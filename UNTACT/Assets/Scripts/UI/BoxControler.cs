﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControler : MonoBehaviour
{
    public GameObject screen;
    private bool isEnter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        if (collision.transform.name == "Box")
        {
            isEnter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.name == "Box")
        {
            isEnter = false;
        }
    }
}
