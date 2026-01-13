using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    public TextMeshProUGUI unlockCostText;
    public GameObject revenueSource, moneyHandler, nextUnlocker;
    public int revenueCost;

    private void Start()
    {
        unlockCostText.text = $"Cost: ${RoundZeros.PrintRound(revenueCost)}";
    }

    public void UnlockRevenue()
    {
        if ((moneyHandler.GetComponent<Currency>().money - revenueCost) >= 0)
        {
            moneyHandler.SendMessage("AddMoney", -revenueCost);
            revenueSource.SetActive(true);
            if (nextUnlocker != null)
            {
                nextUnlocker.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
