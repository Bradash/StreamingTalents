using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public float money = 100;

    float timer = 0;

    private void Awake()
    {
        timer = 0;
    }

    void Update()
    {
        moneyText.text = "Gems:" + RoundZeros.PrintRound(money);

        if (timer > 15)
        {
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    void AddMoney(float amount)
    {
        money += amount;
    }
}
