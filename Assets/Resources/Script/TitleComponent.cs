﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleComponent : MonoBehaviour
{
    void Start()
    {
            GameManager.playerLives = 3; 
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("shop");
        }
    }
}
