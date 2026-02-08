using UnityEngine;

[CreateAssetMenu(menuName = "Game/Game State")]
public class GameState : ScriptableObject
{
    public bool isDay = true;

    // optional expansion
    public int dayCount;
    public float timeOfDay; // 0–24, etc.
}