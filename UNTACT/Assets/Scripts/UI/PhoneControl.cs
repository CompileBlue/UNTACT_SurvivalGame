using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class PhoneControl : MonoBehaviour
{
    private Vector2 mouseStart;
    private Vector2 mouseNow;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, -6, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnMouseDrag()
    {
        mouseNow = Input.mousePosition;
        if (transform.position.y < -2 && mouseNow.y - mouseStart.y > 0)
        {
            transform.position += new Vector3(0, 1, 0);
        }
        if (transform.position.y > -5 && mouseNow.y - mouseStart.y < 0)
        {
            transform.position -= new Vector3(0, 1, 0);
        }
    }
    private void OnMouseDown()
    {
        mouseStart = Input.mousePosition;
    }


}
