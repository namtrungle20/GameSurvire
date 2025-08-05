using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    protected static UIController instance; // singleton instance
    public static UIController Instance { get => instance;}
    [SerializeField] private Slider PlayerHeartSlider; // slider for health
    public GameObject GameOverPanel; // game over panel
    public GameObject PausePanel; // pause panel
    public TMP_Text timerText; // timer text
    void Awake()
    {
        if (instance != null)
            Debug.LogError("có nhiều hơn một UIController trong scene");
        instance = this; // set the singleton instance
    }
    public void UpdatePlayerHeartSlider(float currentHealth, float maxHealth)
    {
        PlayerHeartSlider.maxValue = Player.player.PlayerMaxHealth;
        PlayerHeartSlider.value = Player.player.PLayerHeart;
    }
    public void UpdateGameTime(float time)
    {
        float min = Mathf.FloorToInt(time / 60); // calculate minutes
        float sec = Mathf.FloorToInt(time % 60); // calculate seconds

        timerText.text = min + ":"+sec.ToString("00"); // update game time
    }
}
