using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofControl : MonoBehaviour
{
    SpriteRenderer sprender;

    private bool isEnter;

    private float transparency;
    // Start is called before the first frame update
    void Start()
    {
        isEnter = false;
        transparency = 1f;
        sprender = gameObject.GetComponent<SpriteRenderer>();
        sprender.color = new Color(1f, 1f, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        Invisible();
    }
    void Invisible()
    {
        if (isEnter)
        {
            if(transparency > 0)
            {
                transparency -= 0.02f;
            }
            else
            {
                transparency = 0;
            }
        }
        else
        {
            if (transparency < 1)
            {
                transparency += 0.02f;
            }
            else
            {
                transparency = 1;
            }
        }
        sprender.color = new Color(1f, 1f, 1f, transparency);
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
