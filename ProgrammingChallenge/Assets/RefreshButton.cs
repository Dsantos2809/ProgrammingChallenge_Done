﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RefreshButton : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("TableOfJson");
    }
}