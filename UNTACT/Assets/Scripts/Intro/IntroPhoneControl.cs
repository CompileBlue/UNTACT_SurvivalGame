using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class IntroPhoneControl : MonoBehaviour
{
    private Vector2 mouseStart;
    private Vector2 mouseNow;

    public static AudioSource audioPlayer;
    public AudioClip vibrationAudio;

    public static bool isVibration;
    public static bool isCall = false;

    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        audioPlayer.clip = vibrationAudio;
        audioPlayer.Stop();
        audioPlayer.loop = true;
        audioPlayer.time = 0;
        audioPlayer.volume = 0.5F;

        transform.localPosition = new Vector3(transform.localPosition.x, -290, transform.localPosition.z);
        // isVibration = true;
    }

    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        if (InnerIntroManager.isCalling == true)
        {
            mouseNow = Input.mousePosition;
            if (transform.localPosition.y <= -120 && mouseNow.y - mouseStart.y > 0)
            {
                transform.localPosition += new Vector3(0, 20f, 0);
            }
            if (transform.localPosition.y >= -280 && mouseNow.y - mouseStart.y < 0)
            {
                transform.localPosition -= new Vector3(0, 20f, 0);
            }
        }
    }
    private void OnMouseDown()
    {
        mouseStart = Input.mousePosition;
    }

    public static void Vibration()
    {
        if (isVibration)
        {
            audioPlayer.Play();
        }
        else
        {
            audioPlayer.Stop();
            audioPlayer.time = 0;
        }
    }
}
