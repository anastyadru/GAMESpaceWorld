using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizedText : MonoBehaviour
{
    public TextObject textObject;
    public Text textComponent;

    private void Start()
    {
        LocalizationManager.OnLanguageChanged += UpdateText;
        UpdateText();
    }

    private void OnDestroy()
    {
        LocalizationManager.OnLanguageChanged -= UpdateText;
    }

    private void UpdateText()
    {
        if (textObject != null && textComponent != null)
        {
            string language = LocalizationManager.CurrentLanguage;
            string key = textComponent.text;
            string translatedText = textObject.GetText(language, key);
            textComponent.text = translatedText;
        }
    }
}