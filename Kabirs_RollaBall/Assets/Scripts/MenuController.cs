using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public GameObject[] pauseUI; //Index 0: button, Index 1: panel

    public void Pause() {
        Time.timeScale = 0;
        pauseUI[0].SetActive(false);
        pauseUI[1].SetActive(true);
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        pauseUI[0].SetActive(true);
        pauseUI[1].SetActive(false);
    }
}
