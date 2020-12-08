using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    public GameObject player, canvas, camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Intro" || SceneManager.GetActiveScene().name == "MainMenu")
        {
            canvas.SetActive(false);
            camera.SetActive(false);
        }
        else
        {
            canvas.SetActive(true);
            camera.SetActive(true);
        }
        DontDestroyOnLoad(player.gameObject);
        DontDestroyOnLoad(canvas.gameObject);
        DontDestroyOnLoad(camera.gameObject);
    }
}
