using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance; // singleton instance
    [SerializeField] private Slider PlayerHeartSlider; // slider for health
    public GameObject GameOverPanel; // game over panel
    public GameObject PausePanel; // pause panel
    public TMP_Text timerText; // timer text
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public void UpdatePlayerHeartSlider(float currentHealth, float maxHealth)
    {
        PlayerHeartSlider.maxValue = Player.instance.PlayerMaxHealth;
        PlayerHeartSlider.value = Player.instance.PLayerHeart;
    }
    public void UpdateGameTime(float time)
    {
        float min = Mathf.FloorToInt(time / 60); // calculate minutes
        float sec = Mathf.FloorToInt(time % 60); // calculate seconds

        timerText.text = min + ":"+sec.ToString("00"); // update game time
    }
}
