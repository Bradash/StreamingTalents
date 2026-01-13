using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public float money = 100;

    void Update()
    {
        moneyText.text = "Money: $" + RoundZeros.PrintRound(money);
    }

    void AddMoney(float amount)
    {
        money += amount;
    }
}
