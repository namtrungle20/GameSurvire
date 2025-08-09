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
    [SerializeField] private Slider ExperieceSlider; // slider for experience
    public GameObject GameOverPanel; // game over panel
    public GameObject PausePanel; // pause panel
    public GameObject LevelUpPanel; // level up panel
    [SerializeField]public TMP_Text timerText; // timer text

    [SerializeField] public LevelUpButton[] levelUpButtons; // array of level up buttons
    void Awake()
    {
        if (Instance != null)
            Debug.LogError("có nhiều hơn một UIController trong scene");
        Instance = this; // set the singleton instance
    }
    public void UpdatePlayerHeartSlider()
    {
        PlayerHeartSlider.maxValue = Player.PlayerInstance.PlayerMaxHealth;
        PlayerHeartSlider.value = Player.PlayerInstance.PLayerHeart;
    }
    public void UpdatePlayerExperieceSlider()
    {
        ExperieceSlider.maxValue = Player.PlayerInstance.playerLevels[Player.PlayerInstance.Level - 1];
        ExperieceSlider.value = Player.PlayerInstance.experience;
    }
    public void UpdateGameTime(float time)
    {
        float min = Mathf.FloorToInt(time / 60); // calculate minutes
        float sec = Mathf.FloorToInt(time % 60); // calculate seconds

        timerText.text = min + ":" + sec.ToString("00"); // update game time
    }

    public void LevelUpPanelOpen()
    {
        LevelUpPanel.SetActive(true); // activate or deactivate level up panel
        Time.timeScale = 0f; // pause the game
    }
    public void LevelUpPanelClose()
    {
        LevelUpPanel.SetActive(false); // deactivate level up panel
        Time.timeScale = 1f; // resume the game
    }
}
