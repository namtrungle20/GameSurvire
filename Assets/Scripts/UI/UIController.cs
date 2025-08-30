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
}
