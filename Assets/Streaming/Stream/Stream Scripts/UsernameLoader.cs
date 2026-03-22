using UnityEngine;

public class UsernameLoader : MonoBehaviour
{
    public UsernameList usernameList;
    public TextAsset csvFile;

    [ContextMenu("Load Usernames")]
    void Load()
    {
        usernameList.LoadFromCSV(csvFile);
    }
}
