using UnityEngine;

public class UsernamePIcker : MonoBehaviour
{
    public Usernames[] messages;  // Assign your ScriptableObjects here in the inspector

    private void Start()
    {
        
    }



    public Usernames GetRandomMessage()
    {
        if (messages.Length == 0) return null;
        int index = Random.Range(0, messages.Length);
        return messages[index];
    }
}
