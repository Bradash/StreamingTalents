using UnityEngine;

[CreateAssetMenu(fileName = "MessageGroup", menuName = "Scriptable Objects/MessageGroup")]
public class MessageGroup : ScriptableObject
{
    public string displayName;
    public bool groupChat;
    public Sprite defaultProfilePicture;
}
