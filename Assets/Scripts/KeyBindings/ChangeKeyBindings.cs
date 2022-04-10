using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 * Script for Key bindings input fields
 */
public class ChangeKeyBindings : MonoBehaviour
{
    public InputField inputField;
    public String key;
    public KeyListener KeyListener;

    private void Start()
    {
        inputField.characterLimit = KeyBindings.GetKeyBinding(key).ToString().Length;
        inputField.SetTextWithoutNotify(KeyBindings.GetKeyBinding(key).ToString());
    }

    public void changeKeyCode()
    {
        KeyCode newcode = KeyListener.getLastPressed();
        if (KeyBindings.SetKeyBinding(key, newcode))
        {
            inputField.characterLimit = newcode.ToString().Length;
            inputField.SetTextWithoutNotify(newcode.ToString());
        }
        else
        {
            inputField.characterLimit = "Not Allowed".Length;
            inputField.SetTextWithoutNotify("Not Allowed");
        }
    }
}
