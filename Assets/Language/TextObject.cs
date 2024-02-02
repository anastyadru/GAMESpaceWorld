using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TextObject", menuName = "Localization/TextObject")]
public class TextObject : ScriptableObject
{
    [SerializeField] private Dictionary<string, string> texts = new Dictionary<string, string>();

    public string GetText(string language, string key)
    {
        string text = "";
        if (texts.TryGetValue(language, out text))
        {
            return text;
        }
        else
        {
            Debug.LogWarning("Text not found for language: " + language);
            return "";
        }
    }
}