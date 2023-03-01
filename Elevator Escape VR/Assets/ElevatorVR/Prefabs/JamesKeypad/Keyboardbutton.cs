using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Keyboardbutton : MonoBehaviour
{
    // Start is called before the first frame update

    Keyboard keyboard;
    TextMeshProUGUI buttonText;
    void Start()
    {
        keyboard = GetComponentInParent<Keyboard>();
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        if (buttonText.text.Length == 1)
        {
            NameToButtonOnText();
            GetComponentInChildren<ButtonVR>().onRelease.AddListener(delegate { keyboard.InsertChar(buttonText.text); });
        }

    }

    public void NameToButtonOnText()
    {
        buttonText.text = gameObject.name;
    }

  
}
