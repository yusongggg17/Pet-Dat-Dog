using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour
{
    public GameObject daCanvas;
    private void Start()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    public void beginGame()
    { 
        AudioListener.pause = false;
        Time.timeScale = 1;
       daCanvas.SetActive(false);
       
    }
}
