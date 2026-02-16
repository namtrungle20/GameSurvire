using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance; // singleton instance
    void Awake()
    {
        Instance = this; // set the singleton instance
    }
    public Slider expLvSlider;
    public TMP_Text expLvText;
    public TMP_Text coinText;
    public TMP_Text timeText;
    public LevelUpButton[] levelUpButtons;
    public GameObject levelUpPanel;

    void Start()
    {

    }
    void Update()
    {

    }

    public void UpdateExperience(int statusExp, int levelExp, int statusLevel)
    {
        expLvSlider.maxValue = levelExp;
        expLvSlider.value = statusExp;
        expLvText.text = "Level " + statusLevel;
    }
    public void SkipLevelUp()
    {
        levelUpPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void UpdateCoins()
    {
        coinText.text = "Coin: " + CoinCotroller.Instance.currentCoins;
    }
    public void UpdateTimer(float time)
    {
        float minutes = Mathf.FloorToInt (time / 60);
        float seconds = Mathf.FloorToInt (time % 60);
        timeText.text = "Time " + minutes + ":" + seconds.ToString("00"); 
    }
}
