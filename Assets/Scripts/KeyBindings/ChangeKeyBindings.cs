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
        inputField.characterLimit = 20;
        inputField.SetTextWithoutNotify(KeyBindings.GetKeyBinding(key).ToString());
    }

    public void changeKeyCode()
    {
        KeyCode newcode = KeyListener.getLastPressed();
        if (newcode == KeyCode.Mouse0)
        {
            inputField.SetTextWithoutNotify("");
            return;
        }
        if (KeyBindings.SetKeyBinding(key, newcode))
        {
            inputField.SetTextWithoutNotify(newcode.ToString());
            StoreKeyBindings.SaveKeyBindings();
            inputField.DeactivateInputField();
        }
        else
        {
            inputField.SetTextWithoutNotify("Not Allowed");
        }
    }
}