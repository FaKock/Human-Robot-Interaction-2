using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public string levelToLoad;
    private float timer = 140f;
    private Text timerSeconds;

    private void Start()
    {
        timerSeconds = GetComponent<Text>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        timerSeconds.text = timer.ToString("f2");
        if (timer <= 0)
        {
            Application.LoadLevel(levelToLoad);
        }
    }
}
