using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    //Normal information
    public static int SelectedMinigame;
    public static int SelectedCollab;
    public static int currentday;
    public static float currentmoney;
    public static float musicVolume;
    public static float sfxVolume;

    //Stats screen
    public static float highestviewers;
    public static float avargeChatMood;
    public static float endOfDayMoney;
    public static float startOfDayMoney;
    public static int todayQuota;

    public static float lastHighestviewers;
    public static float lastAvargeChatMood;
    public static float lastIncome;
    public static float lastBalance;
    public static float lastTodayQuota;

    static public Dictionary<string, Dictionary<string, bool>> tutorialList = new()
    {
        {"Movement", new Dictionary<string, bool>{ { "Use WASD to move, use the mouse to look", false } } },
        {"Interaction", new Dictionary<string, bool>{ { "Use the key E or the left mouse button to interact with highlighted objects", false } } }
    };
}
