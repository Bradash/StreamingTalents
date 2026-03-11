using UnityEngine;

[CreateAssetMenu(fileName = "TextingOption", menuName = "Scriptable Objects/TextingOption")]
public class TextingOption : ScriptableObject
{
    public string optionText;
    public TextMessage nextMessage;

    public float WolfRelationChange;
    public float UnicornRelationChange;
    public float DragonRelationChange;

}
