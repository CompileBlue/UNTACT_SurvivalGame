using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RefrigeratorButtonControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        if(PlayerControl.itemList[transform.parent.name] >= 1)
        {
            PlayerControl.itemList[transform.parent.name] -= 1;

            GameObject count = transform.GetChild(0).gameObject;
            TextMeshProUGUI count_text = count.GetComponent<TextMeshProUGUI>();
            count_text.text = PlayerControl.itemList[transform.parent.name].ToString();
            if (PlayerControl.itemList[transform.parent.name] <= 0)
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
