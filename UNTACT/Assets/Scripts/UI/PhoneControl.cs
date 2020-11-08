using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PhoneControl : MonoBehaviour
{
    Vector2 mouseStart;
    Vector2 mouseNow;

    private bool isOn;
    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
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
        if (transform.position.y > -5.5 && mouseNow.y - mouseStart.y < 0)
        {
            transform.position -= new Vector3(0, 1, 0);
        }
    }
    private void OnMouseDown()
    {
        mouseStart = Input.mousePosition;
    }
}
