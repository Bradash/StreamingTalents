using UnityEngine;

[CreateAssetMenu(fileName = "Usernames", menuName = "Scriptable Objects/Usernames")]
public class Usernames : ScriptableObject
{
    [TextArea]
    public string messageText;
}
