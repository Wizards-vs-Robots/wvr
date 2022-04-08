using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeKeyBindings : MonoBehaviour
{
    public InputField inputField;
    public String key;

    private void Start()
    {
        inputField.SetTextWithoutNotify(KeyBindings.GetKeyBinding(key).ToString());
        inputField.SetTextWithoutNotify("A");
    }

    public void changeKeyCode()
    {
        KeyCode newcode = (KeyCode) inputField.text[0];
        KeyBindings.SetKeyBinding(key,newcode);
    }
    
}
