using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }

    public void PauseMenu()
    {
        ThrowWeapon.canThrow = false;
        Time.timeScale = 0;
    }

    public void BackPauseMenu()
    {
        Time.timeScale = 1;
        ThrowWeapon.canThrow = true;
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
