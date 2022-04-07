using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeKeyBindings : MonoBehaviour
{
    public InputField inputField;
    public int keybinding;

    private void Start()
    {
        inputField.SetTextWithoutNotify(KeyBindings.player1_move_up.ToString());
    }

    public void changeKeyCode()
    {
        KeyCode newcode = (KeyCode) inputField.text[0];
        

        switch (keybinding)
         {
             case 0:
                 KeyBindings.player1_move_up = newcode;
                 break;
         }
    }
    
}
