using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;
    private bool isTimerRunning = false;

    void Start()
    {
        timerText.text = "Tempo: 0";
    }

    void Update()
    {
        if (isTimerRunning && !pauseMenu.GameIsPaused) // Verifica se o jogo não está pausado
        {
            float elapsedTime = Time.time - startTime;
            UpdateTimerUI(elapsedTime);
        }
    }

    public void StartTimer()
    {
        isTimerRunning = true;
        startTime = Time.time;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    private void UpdateTimerUI(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);

        timerText.SetText("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}