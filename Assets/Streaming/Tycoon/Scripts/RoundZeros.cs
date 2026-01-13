using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundZeros
{
    public static string PrintRound(float amount)
    {
        if(amount < 1000)
        {
            return Mathf.Round(amount).ToString();
        } 
        else if (amount < 1000000)
        {
            return $"{Mathf.Round(amount / 100) / 10}k";
        } 
        else if (amount < 1000000000)
        {
            return $"{Mathf.Round(amount / 100000) / 10}m";
        }
        else if (amount < 1000000000000)
        {
            return $"{Mathf.Round(amount / 100000000) / 10}b";
        }
        else if (amount < 1000000000000000)
        {
            return $"{Mathf.Round(amount / 100000000000) / 10}t";
        }
        else
        {
            return $"{Mathf.Round(amount / 100000000000000 / 10)}q";
        }
    }
}
