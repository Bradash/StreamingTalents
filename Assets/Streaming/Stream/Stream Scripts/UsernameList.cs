using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UsernameList", menuName = "Scriptable Objects/UsernameList")]
public class UsernameList : ScriptableObject
{
    public List<string> usernames = new List<string>();

    public void LoadFromCSV(TextAsset csvFile)
    {
        usernames.Clear();

        string[] lines = csvFile.text.Split('\n');

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            // Split by comma and take the first value
            string[] parts = line.Split(',');

            string username = parts[0].Trim();

            if (!string.IsNullOrEmpty(username))
            {
                usernames.Add(username);
            }
        }

        Debug.Log("Loaded " + usernames.Count + " usernames!");
    }
}
