using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bgmControl : MonoBehaviour
{
    private AudioSource audioPlayer;
    public AudioClip bgmMenu;
    public AudioClip bgmIntro;
    public AudioClip bgmGame;

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();

        audioPlayer.clip = bgmMenu;
        audioPlayer.Play();
        audioPlayer.loop = true;
        audioPlayer.time = 0;
        audioPlayer.volume = 0.5F;
    }

    // Update is called once per frame
    void Update()
    {
        Audio();
    }

    void Audio()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name == "CreateCharacter")
        {
            audioPlayer.clip = bgmMenu;
        }
        else if (SceneManager.GetActiveScene().name == "Intro")
        {
            if(audioPlayer.clip != bgmIntro)
            {
                audioPlayer.Stop();
                audioPlayer.clip = bgmIntro;
                audioPlayer.Play();
            }
        }

    }
}
