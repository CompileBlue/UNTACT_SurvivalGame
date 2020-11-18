﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    public static Dictionary<string, int> itemList = new Dictionary<string, int>();
    public static Dictionary<string, int> inventoryList = new Dictionary<string, int>();
    public static Dictionary<string, int> refrigeratorList = new Dictionary<string, int>();
    public static int inventoryMax = 10;
    public static int inventoryNow = 0;
    public static Dictionary<string, string[]> chatList = new Dictionary<string, string[]>();
    

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI dayText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI satiationText;
    public TextMeshProUGUI diseaseText;
    public TextMeshProUGUI tutorialText;

    public float moveSpeed;

    private float playTime = 36000f;
    private int playDay = 1;
    private float thisTime = 36000f;

    public static int satiation = 100;
    private int satiationSpeed = 1;
    private int health = 100;
    private int healthSpeed = 1;
    private string disease = "normal";

    private bool isTutorial = true;

    Rigidbody2D playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Status();
        PhoneUI();
        TimeControl();
    }
    void Move()
    {
        /* This function is used for movement of player. 
         * If you press Arrow Key, the player will move.*/

        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * moveSpeed;
        float ySpeed = yInput * moveSpeed;

        Vector3 newVelocity = new Vector3(xSpeed, ySpeed, 0f);

        if (NPCControl.isTalk == true)
        {
            playerRigidbody.velocity = Vector3.zero;
        }
        else
        {
            playerRigidbody.velocity = newVelocity;
        }
    }
    
    void Status()
    {
        playTime += Time.deltaTime;

        if((int)playTime % 3 == 0 && thisTime != (int)playTime)
        {
            thisTime = (int)playTime;
            satiation -= satiationSpeed;
            health -= healthSpeed;
        }
        if(satiation >= 100)
        {
            satiation = 100;
        }
        if (health >= 100)
        {
            health = 100;
        }
    }
    void PhoneUI()
    {
        timeText.text = ((int)(playTime / 3600)).ToString("00") + ":" + ((int)(playTime % 3600 / 60)).ToString("00");
        timeText.text += (playTime >= 43200) ? " pm" : " am";
        healthText.text = "Health:" + health.ToString();
        satiationText.text = "Hungry:" + satiation.ToString();
        diseaseText.text = "Disease:" + disease;

    }
    void TimeControl()
    {
        if(playTime >= 86400)
        {
            playTime = 0;
            playDay += 1;
        }
        if(playTime >= 79200)
        {
            playTime = 36000;
            playDay += 1;
        }
        dayText.text = "Day - " + playDay.ToString();
    }
    /*void Tutorial()
    {
        if (isTutorial)
        {
            isTutorial = false;

        }
    }*/

}
