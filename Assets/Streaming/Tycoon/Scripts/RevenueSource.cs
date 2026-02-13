using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class RevenueSource : MonoBehaviour
{
    public GameObject upgradeButton;
    GameObject moneyHandler;
    public string sourceName;
    public TextMeshProUGUI buttonText, timerText, revenueAmountText, upgradeCostText, levelText;
    public Slider cooldownSlider;

    public float revenue;
    public float revenueTime;
    float currentTimer;
    float upgradeMultiplier = 1.15f;
    public int maxLevel = 100;
    int currentLevel = 1;
    bool automatic = false;

    public float upgradeCost;
    float upgradeCostMultiplier = 1.15f;

    bool onCooldown = true;

    void Start()
    {
        moneyHandler = GameObject.Find("Money Handler");

        currentTimer = 0;
        buttonText.text = sourceName;
        timerText.text = "Ready!";
        revenueAmountText.text = "$" + RoundZeros.PrintRound(revenue);
        upgradeCostText.text = "Cost: $" + RoundZeros.PrintRound(upgradeCost);
        levelText.text = $"Level: {currentLevel.ToString()}/{maxLevel}";

        cooldownSlider.minValue = 0;
        cooldownSlider.maxValue = revenueTime;
        cooldownSlider.value = revenueTime - currentTimer;
    }

    void Update()
    {
        if (currentTimer > 0)
        {
            currentTimer -= Time.deltaTime;
            cooldownSlider.value = revenueTime - currentTimer;
            timerText.text = "Cooldown: " + Mathf.Round(currentTimer).ToString();
        }
        else if (onCooldown)
        {
            {
                cooldownSlider.value = revenueTime;
                onCooldown = false;
                timerText.text = "Ready!";
            }
        }

        if (automatic)
        {
            UseSource();
        }
    }

    public void UpgradeRevenue()
    {
        if ((moneyHandler.GetComponent<Currency>().money - upgradeCost) >= 0)
        {
            revenue *= upgradeMultiplier;
            revenue = Mathf.Round(revenue);
            revenueAmountText.text = "$" + RoundZeros.PrintRound(revenue);
            moneyHandler.SendMessage("AddMoney", -upgradeCost);
            upgradeCost *= upgradeCostMultiplier;
            upgradeCost = Mathf.Round(upgradeCost);
            upgradeCostText.text = "Cost: $" + RoundZeros.PrintRound(upgradeCost);
            currentLevel++;
            levelText.text = $"Level: {currentLevel.ToString()}/{maxLevel}";

            if (currentLevel >= 30)
            {
                automatic = true;
            }

            if (currentLevel >= 100)
            {
                upgradeButton.SetActive(false);
            }
        }
    }

    public void UseSource()
    {
        if (!onCooldown)
        {
            moneyHandler.SendMessage("AddMoney", revenue);
            UIStatsManager.Instance.points += 5;
            currentTimer = revenueTime;
            onCooldown = true;
        }
    }
}
