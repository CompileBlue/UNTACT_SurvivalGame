using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    public static Dictionary<int, int> itemList = new Dictionary<int, int>();
    public float moveSpeed;

    private float playTime = 0f;
    private float thisTime = 0f;

    private float satiation = 100;
    private float satiationSpeed = 1f;
    private float health = 100;
    private float healthSpeed = 1;

    private bool isTutorial = true;

    public TextMeshProUGUI tutorialText;
    Rigidbody2D playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        tutorialText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Status();
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
        playerRigidbody.velocity = newVelocity;
    }
    
    void Status()
    {
        playTime += Time.deltaTime;

        if((int)playTime % 10 == 0 && thisTime != (int)playTime)
        {
            thisTime = (int)playTime;
            satiation -= satiationSpeed;
            Debug.Log(satiation);
        }
    }
    void Tutorial()
    {
        if (isTutorial)
        {
            isTutorial = false;

        }
    }

}
