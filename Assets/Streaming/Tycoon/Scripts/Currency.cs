using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public float money = 100;

    public TextMeshProUGUI tutorial;
    float timer = 0;

    private void Awake()
    {
        tutorial.enabled = true;
        timer = 0;
    }

    void Update()
    {
        moneyText.text = "Gems:" + RoundZeros.PrintRound(money);

        if (timer > 15)
        {
            tutorial.enabled=false;
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
