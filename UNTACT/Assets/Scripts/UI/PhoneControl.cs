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
        transform.localPosition = new Vector3(transform.localPosition.x, -160, transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnMouseDrag()
    {
        mouseNow = Input.mousePosition;
        if (transform.localPosition.y <= -40 && mouseNow.y - mouseStart.y > 0)
        {
            transform.localPosition += new Vector3(0, 20f, 0);
        }
        if (transform.localPosition.y >= -140 && mouseNow.y - mouseStart.y < 0)
        {
            transform.localPosition -= new Vector3(0, 20f, 0);
        }
    }
    private void OnMouseDown()
    {
        mouseStart = Input.mousePosition;
    }


}
