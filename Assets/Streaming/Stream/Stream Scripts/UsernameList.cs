using System.Collections.Generic;
using UnityEditor;
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

            string username = line.Split(',')[0].Trim();

            if (!string.IsNullOrEmpty(username))
            {
                usernames.Add(username);
            }
        }

#if UNITY_EDITOR
        EditorUtility.SetDirty(this);  // Marks asset as changed
        AssetDatabase.SaveAssets();   // Actually saves it
#endif

        Debug.Log("Loaded " + usernames.Count + " usernames!");
    }
}
