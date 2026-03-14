using UnityEngine;

[CreateAssetMenu(fileName = "SelectionObject", menuName = "Scriptable Objects/SelectionObject")]
public class SelectionObject : ScriptableObject
{
    public string elementName;
    public Sprite elementImage;
    public int gameID;
    public int dayUnlocked;
}
